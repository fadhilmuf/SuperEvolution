using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Canvas shopCanvas;
    public Button openButton;

    void Start()
    {
        openButton = GetComponent<Button>();
        openButton.onClick.AddListener(shopOpen);
    }

    void shopOpen()
    {
        shopCanvas.enabled = true;
    }
}
