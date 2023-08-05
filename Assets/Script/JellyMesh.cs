using UnityEngine;

public class JellyMesh : MonoBehaviour
{
    public Detector detector;
    
    private float jellyStrength = 1f;
    public float jellyDamping = 0.2f;
    private float jellyFrequency = 3f;
    
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
        if(detector.detectPlayer == true)
        {
            jellyFrequency = 7f;
        }
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

