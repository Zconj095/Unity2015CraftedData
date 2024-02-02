using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class NormalMapApplication : MonoBehaviour
{
    public Texture2D normalMap; // Assign this in the inspector
    public Vector3 baseNormal = Vector3.up; // A default base normal pointing up

    void Start()
    {
        ApplyNormalMap();
    }

    void ApplyNormalMap()
    {
        Material objMaterial = GetComponent<Renderer>().material;

        // Assuming the shader has a normal map property named "_BumpMap"
        if (normalMap != null)
        {
            objMaterial.SetTexture("_BumpMap", normalMap);
        }

        // This script doesn't directly apply the baseNormal since normal maps adjust normals based on their encoded data.
        // However, this line is here to illustrate where you might use the baseNormal in custom shader calculations or script-based adjustments.
        // In practice, Unity's standard shader and most custom shaders automatically handle normal mapping.
    }
}
