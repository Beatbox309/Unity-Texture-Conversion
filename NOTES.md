
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
 - inverting channel
 - set channel value directly




Converter		 = an interface for Packer Presets.
Packer Preset	 = a saveable collection of Input Textures with their channel/operator data.
Input Texture	 = a Texture that passes it's channel data to the output Texture, optionally passing through an Operator.
Channel Operator = a shader that transforms a Texture.

Example:
	We have Metallic and Roughness maps, but we need a MetallicSmoothness map.
	We can setup a Packer Preset like this:
	
	MetalSmooth Preset {
		Metallic.Red  -> Output.Red
		Roughness.Red -> Output.Alpha
	}

	You can now use this preset generically, just select the preset and pass in your Textures.


Let's say we needed to transform a set of correlated Textures. We could make Packer Presets for each Output, but there's a lot of redundancies and is slow to use.
Instead we can make a Converter, which acts as an interface for a set of Presets.
Example:

	RipDiffuse Preset {
		Diff.RGB		   -> Output.RGB
		Operator.Set(255) -> Output.Alpha
	}
	
	RipMetallicSmooth Preset {
		//	Metallic map is stored in the ripped diffuse's alpha channel
		Diff.Alpha -> Output.Red
		Gloss.Red  -> Output.Alpha
	}

	RipNormal Preset {
		Normal.Alpha	  -> Output.Red
		Normal.Green	  -> Output.Green
		Operator.Set(255) -> Output.BA
	}


	UnityRipToValveVRStandard Converter {
		Inputs: Diffuse, Gloss, Normal

		Diffuse -> RipDiffuse
		Diffuse, Gloss -> RipMetallicSmooth
		Normal  -> RipNormal
	}

	We can now just pass in our three Textures, and the Converter will apply the Presets and output each one seperately
