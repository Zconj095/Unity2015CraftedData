using UnityEngine;

public class RoughnessMapApplication : MonoBehaviour
{
    public Texture2D roughnessMap; // Assign in the inspector
    public Light directionalLight; // Assign the main light in the inspector

    void Start()
    {
        ApplyRoughnessMap();
    }

    void ApplyRoughnessMap()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer component not found.");
            return;
        }

        // Assuming a custom shader with properties for the roughness map
        Material material = renderer.material;
        material.SetTexture("_RoughnessMap", roughnessMap);

        // Pass light direction to the shader
        if (directionalLight != null)
        {
            Vector3 lightDirection = directionalLight.transform.forward;
            material.SetVector("_LightDirection", lightDirection);
        }
    }
}
