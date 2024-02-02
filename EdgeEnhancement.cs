using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class EdgeEnhancement : MonoBehaviour
{
    public Texture2D edgeMapTexture; // Assign this in the inspector
    public float edgeIntensity = 1.0f; // Default global edge intensity

    void Start()
    {
        ApplyEdgeMap();
    }

    void ApplyEdgeMap()
    {
        Material objMaterial = GetComponent<Renderer>().material;

        // Assuming the shader has properties for the edge map and edge intensity
        if (edgeMapTexture != null)
        {
            objMaterial.SetTexture("_EdgeMap", edgeMapTexture);
        }
        objMaterial.SetFloat("_EdgeIntensity", edgeIntensity);
    }
}
