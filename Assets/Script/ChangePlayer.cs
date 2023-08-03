using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    public Mesh newMesh;
    private Mesh originalMesh;
    private Button changeButton;
    public GameObject player;
    private MeshFilter meshFilter;
    public ColliderHandler coll;
    public Canvas EvoCard;

    //Run the time again
    public PlayerControllerExample playerControl;
    public EnemyController enemy;

    void Start()
    {
        changeButton = GetComponent<Button>();
        changeButton.onClick.AddListener(Change);
        
        meshFilter = player.GetComponent<MeshFilter>();

        originalMesh = meshFilter.sharedMesh;
    }

    private void Change()
    {
        if(newMesh != null)
            {
                meshFilter.sharedMesh = newMesh;
            }
        if(EvoCard == true)
        {
            EvoCard.enabled = false;
            playerControl.playerStop = 1f;
            enemy.EnemyStop = 1f;
        }
    }

}
