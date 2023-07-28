using UnityEngine;
using UnityEngine.UI;

public class ShopClosed : MonoBehaviour
{
    public Canvas shopCanvas;
    public Button closedButton;
    public PlayerControllerExample player;
    public EnemyController enemy;

    void Start()
    {
        closedButton = GetComponent<Button>();
        closedButton.onClick.AddListener(shopClosed);
    }

    void shopClosed()
    {
        player.playerStop = 1f;
        enemy.EnemyStop = 1f;
        shopCanvas.enabled = false;
    }
}
