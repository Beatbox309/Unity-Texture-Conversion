from PIL import Image
from PIL import ImageChops
import pathlib
import os

def SplitImg(_img):
    if(_img.mode == "RGBA"):
        _R,_G,_B,_A = _img.split()
        return (_R,_G,_B,_A)
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

def CreateBWImg(_size,_col):
    _newImg = Image.new("L",_size,color=_col)
    return _newImg

def Convert(normPath):
    # setup
    ogNorm = Image.open(normPath)
    normTuple = SplitImg(ogNorm)

    # Invert Blue Channel
    invB = ImageChops.invert(normTuple[2])
    normTuple = (normTuple[0],normTuple[1],invB)
    
    
    # Normal Map
    nrmWhite = CreateBWImg(ogNorm.size,255)
    normal = Image.merge("RGBA",(normTuple[0],normTuple[1],normTuple[2],nrmWhite))
    normal.save(workingDir + "NormalMap.png")


ogNormalPath = ""

with open(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt") as file:
    line = file.readlines()
    ogNormalPath = line[0]

ogNormalPath = ogNormalPath.rstrip("\n")

workingDir = str(pathlib.Path(ogNormalPath).parent.absolute()) + '\\'
Convert(ogNormalPath)

os.remove(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt")


