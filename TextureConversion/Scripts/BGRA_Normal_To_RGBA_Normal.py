from PIL import Image
import pathlib
import sys

sys.path.append(str(pathlib.Path(__file__).parent.absolute()))
import TextureConversionMain as tcm


def Convert(normPath):
    # setup
    ogNorm = Image.open(normPath)
    normTuple = tcm.SplitImg(ogNorm)
    print("Images Loaded")

    # Normal Map
    nrmWhite = tcm.CreateBWImg(ogNorm.size,255)
    
    normal = Image.merge("RGBA",(normTuple[3],normTuple[1],nrmWhite,nrmWhite))
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
