using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PlayerControllerExample player;
    public EnemyController enemy;
    public Canvas shopCanvas;
    public Button openButton, closedButton, coinButton;


    void Start()
    {
        openButton.onClick.AddListener(ShopOpen);
        closedButton.onClick.AddListener(ShopClosed);
        coinButton.onClick.AddListener(ShopOpen);
    }

    void ShopOpen()
    {
        player.playerStop = 0f;
        enemy.EnemyStop = 0f;
        shopCanvas.enabled = true;
    }
    void ShopClosed()
    {
        player.playerStop = 1f;
        enemy.EnemyStop = 1f;
        shopCanvas.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            shopCanvas.enabled = true;
        }
    }
}
