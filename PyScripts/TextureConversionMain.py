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

def RemoveTempFiles():
    tempPath = str(pathlib.Path(__file__).parent.absolute()) + '\\' + "Temp.txt"
    os.remove(tempPath)
    try:
        os.remove(tempPath + ".meta")
    except:
        pass
