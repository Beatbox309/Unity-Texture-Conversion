from PIL import Image
from PIL import ImageChops
import pathlib
import sys

sys.path.append(str(pathlib.Path(__file__).parent.absolute()))
import TextureConversionMain as tcm


def Convert(normPath):
    # setup
    ogNorm = Image.open(normPath)
    normTuple = tcm.SplitImg(ogNorm)
    print("Images Loaded")

    # Invert Blue Channel
    invB = ImageChops.invert(normTuple[2])
    normTuple = (normTuple[0],normTuple[1],invB)
    print("Image Inverted")
    
    # Normal Map
    nrmWhite = tcm.CreateBWImg(ogNorm.size,255)
    normal = Image.merge("RGBA",(normTuple[0],normTuple[1],normTuple[2],nrmWhite))
    normal.save(workingDir + "NormalMap.png")
    print("Images Saved!")


ogNormalPath = ""

with open(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt") as file:
    line = file.readlines()
    ogNormalPath = line[0]

ogNormalPath = ogNormalPath.rstrip("\n")

workingDir = str(pathlib.Path(ogNormalPath).parent.absolute()) + '\\'
Convert(ogNormalPath)

tcm.RemoveTempFiles()
