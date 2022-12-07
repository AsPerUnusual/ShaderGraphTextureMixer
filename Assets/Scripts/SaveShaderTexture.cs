using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//https://gamedev.stackexchange.com/questions/125371/how-to-write-from-shader-to-a-texture-to-a-png-in-unity
// last answer, with some changes and noted fix in the comments, that "buffer" was declared twice, Unity didn't like the lack of a close paren ahead of the 2nd declaration...

public class SaveShaderTexture : MonoBehaviour
{
	[SerializeField]
	private int TextureLength = 1024;

	[SerializeField]
	private string baseFilename = "UntitledTexture";

	private Texture2D texture;
    
	public void Save()
	{
		RenderTexture buffer = new RenderTexture( 
			TextureLength, 
			TextureLength, 
			0,                            // depth setting
			RenderTextureFormat.ARGB32,   // Standard colour format
 			RenderTextureReadWrite.sRGB // do sRGB conversions
		);

		texture = new Texture2D(TextureLength,TextureLength,TextureFormat.ARGB32,true);

		MeshRenderer render = GetComponent<MeshRenderer>();
        
		Material material = render.sharedMaterial;

		Graphics.Blit(null, buffer, material);
		RenderTexture.active = buffer;           // If not using a scene camera

		texture.ReadPixels(
			new Rect(0, 0, TextureLength, TextureLength), // Capture the whole texture
			0, 0,                          // Write starting at the top-left texel
			false);                          // No mipmaps

		System.IO.File.WriteAllBytes( Application.dataPath + "/"+ baseFilename + ".png", texture.EncodeToPNG() ); 
        
		
		  //Debug.Log(EditorApplication.applicationPath);
		 // Debug.Log(Application.dataPath);
	}

	void Start()
	{
	
	}

	void Update()
	{

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Save();
		}
	}
}
