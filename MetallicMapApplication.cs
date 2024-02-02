using UnityEngine;

public class MetallicMapApplication : MonoBehaviour
{
    public Texture2D metallicMap; // Assign in the inspector
    public Color diffuseColor = Color.gray; // Default non-metallic color
    public Color metallicColor = Color.white; // Default metallic color

    void Start()
    {
        ApplyMetallicProperties();
    }

    void ApplyMetallicProperties()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer component not found.");
            return;
        }

        // Assuming a custom shader with these properties
        Material material = renderer.material;
        material.SetTexture("_MetallicMap", metallicMap);
        material.SetColor("_DiffuseColor", diffuseColor);
        material.SetColor("_MetallicColor", metallicColor);
    }
}
