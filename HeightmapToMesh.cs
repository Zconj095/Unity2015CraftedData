using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class HeightmapToMesh : MonoBehaviour
{
    public Texture2D heightmap;
    public float maxHeight = 10.0f; // H_max in scene units

    void Start()
    {
        ApplyHeightmap();
    }

    void ApplyHeightmap()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        Vector3[] vertices = mesh.vertices;

        // Assuming the heightmap and mesh vertex count are compatible
        // This loop goes through each vertex and adjusts its height based on the heightmap
        for (int i = 0; i < vertices.Length; i++)
        {
            // Calculate texture coordinates for the vertex
            float xCoord = Mathf.Clamp01(vertices[i].x / mesh.bounds.size.x + 0.5f);
            float yCoord = Mathf.Clamp01(vertices[i].y / mesh.bounds.size.z + 0.5f);

            // Sample the heightmap
            float height = heightmap.GetPixelBilinear(xCoord, yCoord).grayscale;

            // Adjust the vertex position based on the heightmap
            vertices[i].y = height * maxHeight;
        }

        // Apply the modified vertices to the mesh
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals(); // Recalculate normals to update lighting
    }
}
