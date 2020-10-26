from PIL import Image
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

def Convert(diffPath,glossPath,normPath):
    # setup
    ogDiff = Image.open(diffPath)
    ogGloss = Image.open(glossPath)
    ogNorm = Image.open(normPath)


    diffTuple = SplitImg(ogDiff)
    glossTuple = SplitImg(ogGloss)
    normTuple = SplitImg(ogNorm)


        
    # Diffuse Map
    diffWhite = CreateBWImg(ogDiff.size,255)
    diffBlack = CreateBWImg(ogDiff.size,0)
    
    diffuse = Image.merge("RGBA",(diffTuple[0],diffTuple[1],diffTuple[2],diffWhite))
    diffuse.save(workingDir + "DiffuseMap.png")

    # MetallicGloss Map
    metallicGloss = Image.merge("RGBA",(diffTuple[3],diffBlack,diffBlack,glossTuple[0]))
    metallicGloss.save(workingDir + "MetallicGloss.png")

    # Normal Map
    nrmWhite = CreateBWImg(ogNorm.size,255)
    
    normal = Image.merge(ogNorm.mode,(normTuple[3],normTuple[1],nrmWhite,nrmWhite))
    normal.save(workingDir + "NormalMap.png")


ogDiffusePath = ""
ogGlossPath = ""
ogNormalPath = ""

with open(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt") as file:
    line = file.readlines()
    ogDiffusePath = line[0]
    ogGlossPath = line[1]
    ogNormalPath = line[2]

ogDiffusePath = ogDiffusePath.rstrip("\n")
ogGlossPath = ogGlossPath.rstrip("\n")
ogNormalPath = ogNormalPath.rstrip("\n")

workingDir = str(pathlib.Path(ogDiffusePath).parent.absolute()) + '\\'
Convert(ogDiffusePath,ogGlossPath,ogNormalPath)

os.remove(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt")


