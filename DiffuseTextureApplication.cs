using UnityEngine;

public class DiffuseTextureApplication : MonoBehaviour
{
    public Texture2D diffuseTexture; // Assign this in the inspector
    public float baseIntensity = 1.0f; // Default intensity
    public float shininessFactor = 1.0f; // Default shininess

    void Start()
    {
        ApplyTextureSettings();
    }

    void ApplyTextureSettings()
    {
        // Ensure the object has a Renderer component
        if (GetComponent<Renderer>() == null)
        {
            Debug.LogError("Renderer component missing on the object.");
            return;
        }

        // Access the material of the Renderer
        Material objMaterial = GetComponent<Renderer>().material;

        // Apply the diffuse texture to the material
        objMaterial.mainTexture = diffuseTexture;

        // Calculate the color modification based on baseIntensity and shininessFactor
        // This is a simplified model and does not accurately represent physical shininess
        Color modifiedColor = new Color(baseIntensity * shininessFactor,
                                         baseIntensity * shininessFactor,
                                         baseIntensity * shininessFactor, 1);

        // Apply the modified color to the material
        objMaterial.color = modifiedColor;
    }
}
