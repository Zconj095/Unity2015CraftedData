using UnityEngine;

public class SpecularMapApplication : MonoBehaviour
{
    public Texture2D specularMap; // Assign in the inspector
    public float shininess = 20.0f; // Default shininess coefficient

    void Start()
    {
        ApplySpecularProperties();
    }

    void ApplySpecularProperties()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer component not found.");
            return;
        }

        Material material = renderer.material;
        material.SetTexture("_SpecularMap", specularMap);
        material.SetFloat("_Shininess", shininess);
    }
}
