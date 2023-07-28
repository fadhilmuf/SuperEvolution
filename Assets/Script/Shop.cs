using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PlayerControllerExample player;
    public EnemyController enemy;
    public Canvas shopCanvas;
    public Button openButton;


    void Start()
    {
        openButton = GetComponent<Button>();
        openButton.onClick.AddListener(shopOpen);
    }

    void shopOpen()
    {
        player.playerStop = 0f;
        enemy.EnemyStop = 0f;
        shopCanvas.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            shopCanvas.enabled = true;
        }
    }
}
