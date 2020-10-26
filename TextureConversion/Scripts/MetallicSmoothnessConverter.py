from PIL import Image
from PIL import ImageChops
import pathlib
import os

def SplitImg(_img):
    if(_img.mode == "RGBA"):
        _R,_G,_B,_A = _img.split()
        return (_R,_G,_B)
    elif(_img.mode == "RGB"):
        _R,_G,_B = _img.split()
        return (_R,_G,_B)
    elif(_img.mode == "L"):
        _L = _img.split()
        return (_L)
    elif(_img.mode == "I"):
        cImg = _img.convert("L")
        _I = cImg.split()
        return (_I)

def Convert(metalPath, roughPath):
    # setup
    ogMetallic = Image.open(metalPath)
    ogRough = Image.open(roughPath)
    
    metalTuple = SplitImg(ogMetallic)
    roughTuple = SplitImg(ogRough)

    # Invert Roughness
    smoothness = ImageChops.invert(roughTuple[0])

    # Metallic Map
    bandsTuple = (metalTuple[0],metalTuple[1],metalTuple[2],smoothness)
    
    metallic = Image.merge("RGBA",bandsTuple)
    metallic.save(workingDir + "MetallicSmoothnessMap.png")


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

os.remove(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt")
