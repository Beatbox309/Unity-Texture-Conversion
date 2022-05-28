from PIL import Image
from PIL import ImageChops
import pathlib
import sys

sys.path.append(str(pathlib.Path(__file__).parent.absolute()))
import TextureConversionMain as tcm


def Convert(metalPath, roughPath):
    # setup
    ogMetallic = Image.open(metalPath)
    ogRough = Image.open(roughPath)
    
    metalTuple = tcm.SplitImg(ogMetallic)
    roughTuple = tcm.SplitImg(ogRough)
    print("Images Loaded")

    # Invert Roughness
    smoothness = ImageChops.invert(roughTuple[0])
    print("Image Inverted")

    # Metallic Map
    bandsTuple = (metalTuple[0],metalTuple[1],metalTuple[2],smoothness)
    
    metallic = Image.merge("RGBA",bandsTuple)
    metallic.save(workingDir + "MetallicSmoothnessMap.png")
    print("Images Saved!")


# Get paths from file
ogRoughPath = ""
ogMetallicPath = ""

with open(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt") as file:
    line = file.readlines()
    ogRoughPath = line[0]
    ogMetallicPath = line[1]

ogRoughPath = ogRoughPath.rstrip("\n")
ogMetallicPath = ogMetallicPath.rstrip("\n")

workingDir = str(pathlib.Path(ogMetallicPath).parent.absolute()) + '\\'
Convert(ogMetallicPath, ogRoughPath)

tcm.RemoveTempFiles()
