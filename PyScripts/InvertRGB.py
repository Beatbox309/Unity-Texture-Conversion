from PIL import Image
from PIL import ImageChops
import pathlib
import sys

sys.path.append(str(pathlib.Path(__file__).parent.absolute()))
import TextureConversionMain as tcm


def Convert(imgPath):
    # setup
    ogImg = Image.open(imgPath)
    imgTuple = tcm.SplitImg(ogImg)
    print("Images Loaded")

    # Invert RGB Channels
    imgR = ImageChops.invert(imgTuple[0])
    imgG = ImageChops.invert(imgTuple[1])
    imgB = ImageChops.invert(imgTuple[2])

    if(ogImg.mode == "RGBA"):
        imgTuple = (imgR,imgG,imgB,imgTuple[3])
    else:
        imgWhite = tcm.CreateBWImg(ogImg.size,255)
        imgTuple = (imgR,imgG,imgB,imgWhite)
    print("Image Inverted")
    
    # Merge Map
    invImg = Image.merge("RGBA",imgTuple)
    invImg.save(workingDir + "InvertedImage.png")
    print("Images Saved!")


ogImagePath = ""
with open(str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt") as file:
    line = file.readlines()
    ogImagePath = line[0]

ogImagePath = ogImagePath.rstrip("\n")

workingDir = str(pathlib.Path(ogImagePath).parent.absolute()) + '\\'
Convert(ogImagePath)

tcm.RemoveTempFiles()
