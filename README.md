### ShaderGraphTextureMixer
A texture mixer / "swizzler" setup using Shader Graph in Unity

A quick way to take images and set them to certain channels and re-arrange those channels as well.

Could be handy for packing greyscale image maps into one RGBA file to save space for example.

File saving script was found here: https://gamedev.stackexchange.com/questions/125371/how-to-write-from-shader-to-a-texture-to-a-png-in-unity

I modified the script slightly to expose the filename in the editor along with a bug fix noted in the comments and removed some unused commented out code.


A screenshot of a plane mapped with the material and the shader inputs:

![Screenshot with demo content](ShaderGraphTextureMixerImage.jpg?raw=true)


To save your results, set the Material as you want with the input images.  Then in the Scene find the GameObject that has the Save Shader Texture Component on it.  Adjust the Texture Length and Base Filename to suit your needs.

![Screenshot with demo content](SaveShaderTextureScreenshot.png?raw=true)

In play mode, press the spacebar to save an image file.  The file will be saved in the Assets folder of the project.

