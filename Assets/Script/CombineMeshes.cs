using UnityEngine;

public class CombineMeshes : MonoBehaviour
{
    private void Start()
    {
        CombineAllMeshes();
    }

    private void CombineAllMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combine, true);

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterials = GetMaterials(meshFilters);
    }

    private Material[] GetMaterials(MeshFilter[] meshFilters)
    {
        Material[] materials = new Material[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            MeshRenderer meshRenderer = meshFilters[i].GetComponent<MeshRenderer>();
            if (meshRenderer != null && meshRenderer.sharedMaterial != null)
            {
                materials[i] = meshRenderer.sharedMaterial;
            }
        }
        return materials;
    }
}
