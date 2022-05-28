
both take input textures and generate output textures


TexConv takes input tex's and runs custom scripts on them
ChannelPacker takes input tex's and blits the selected channels to a generated tex


i want to combine them; create presets for packing channels

InputTex:
   Dict(inputChannel, outputChannel)
   optional operation?

Preset:
   name/info
   List(InputTex)
   settings




I also want to include custom operations
e.g. 
 - inverting channels
 - 





3 levels of abstraction

1. Presets
2. Channel Packer with Operations
3. Custom Operation Shaders



