using UnityEngine;

public class JellyMesh : MonoBehaviour
{
    public float jellyStrength = 0.1f;
    public float jellyDamping = 0.1f;
    public float jellyFrequency = 1f;
    
    private Vector3[] originalVertices;
    
    private void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            originalVertices = meshFilter.mesh.vertices;
        }
    }
    
    private void Update()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;
            Vector3[] vertices = mesh.vertices;
            
            for (int i = 0; i < vertices.Length; i++)
            {
                // Calculate displacement using a sine wave
                Vector3 displacement = originalVertices[i] * Mathf.Sin(Time.time * jellyFrequency) * jellyStrength;
                
                // Apply damping to smooth the effect
                vertices[i] = Vector3.Lerp(vertices[i], originalVertices[i] + displacement, jellyDamping * Time.deltaTime);
            }
            
            mesh.vertices = vertices;
            mesh.RecalculateNormals();
        }
    }
}

