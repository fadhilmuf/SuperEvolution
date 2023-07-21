using UnityEngine;
using UnityEngine.UI;

public class ShopClosed : MonoBehaviour
{
    public Canvas shopCanvas;
    public Button closedButton;

    void Start()
    {
        closedButton = GetComponent<Button>();
        closedButton.onClick.AddListener(shopClosed);
    }

    void shopClosed()
    {
        shopCanvas.enabled = false;
    }
}
