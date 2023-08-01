using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public Mesh newMesh;
    
    private MeshFilter meshFilter;
    private Mesh originalMesh;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        originalMesh = meshFilter.sharedMesh;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(newMesh != null)
            {
                meshFilter.sharedMesh = newMesh;
            }
        }
    }

    private void OnDisable()
    {
        meshFilter.sharedMesh = originalMesh;
    }

}
