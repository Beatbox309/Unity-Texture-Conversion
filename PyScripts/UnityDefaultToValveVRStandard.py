from PIL import Image
import pathlib
import sys

sys.path.append(str(pathlib.Path(__file__).parent.absolute()))
import TextureConversionMain as tcm


def Convert(diffPath,glossPath,normPath):
    # setup
    ogDiff = Image.open(diffPath)
    ogGloss = Image.open(glossPath)
    ogNorm = Image.open(normPath)

    diffTuple = tcm.SplitImg(ogDiff)
    glossTuple = tcm.SplitImg(ogGloss)
    normTuple = tcm.SplitImg(ogNorm)
    print("Images Loaded")

    # Diffuse Map
    diffWhite = tcm.CreateBWImg(ogDiff.size,255)
    diffBlack = tcm.CreateBWImg(ogDiff.size,0)
    
    diffuse = Image.merge("RGBA",(diffTuple[0],diffTuple[1],diffTuple[2],diffWhite))
    diffuse.save(workingDir + "DiffuseMap.png")

    # MetallicGloss Map
    metallicGloss = Image.merge("RGBA",(diffTuple[3],diffBlack,diffBlack,glossTuple[0]))
    metallicGloss.save(workingDir + "MetallicGloss.png")

    # Normal Map
    nrmWhite = tcm.CreateBWImg(ogNorm.size,255)
    
    normal = Image.merge("RGBA",(normTuple[3],normTuple[1],nrmWhite,nrmWhite))
    normal.save(workingDir + "NormalMap.png")
    print("Images Saved!")


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

tcm.RemoveTempFiles()
