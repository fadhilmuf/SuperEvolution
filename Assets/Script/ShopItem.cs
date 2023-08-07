using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public ColliderHandler coll;
    public PlayerControllerExample player;

    public Button lifeItem, speedItem, coinItem, coinItemClosed;
    public Canvas paymentCanvas;

    void Start()
    {
        lifeItem.onClick.AddListener(Life);
        speedItem.onClick.AddListener(Speed);
        coinItem.onClick.AddListener(CoinOpen);
        coinItemClosed.onClick.AddListener(CoinClosed);
    }

    void Life()
    {
        if(coll.coin >= 3)
        {
            coll.coin -= 3;
            coll.life++;
        }
    }
    void Speed()
    {
        if(coll.coin >= 2)
        {
            coll.coin -= 2;
            player.playerSpeed++;
        }
    }
    void CoinOpen()
    {
        paymentCanvas.enabled = true;
    }
    void CoinClosed()
    {
        paymentCanvas.enabled = false;
    }
}
