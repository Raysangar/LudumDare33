using UnityEngine;
using System.Collections;

public class SealDrawer : MonoBehaviour {
    private Material originalMaterial;
    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void sealStarted(Vector3 startingPoint)
    {
        //check starting point

    }

    public void drawOn(Vector2 textureCoordinate)
    {
        Material startingMaterial = meshRenderer.material;
        Texture2D sealTexture = startingMaterial.mainTexture as Texture2D;
        Texture2D newTexture = new Texture2D(sealTexture.width, sealTexture.height, TextureFormat.ARGB32, false);
        newTexture.SetPixels32(sealTexture.GetPixels32());
        Color color = new Color(0, 0, 1, 1);
        newTexture.SetPixel((int)(textureCoordinate.x * sealTexture.width), (int)(textureCoordinate.y * sealTexture.height), color);
        newTexture.Apply();
        Material material = new Material(startingMaterial);
        material.mainTexture = newTexture;
        meshRenderer.material = material;
    }

    public void setOriginalTexture()
    {
        meshRenderer.material = originalMaterial;
    }
}
