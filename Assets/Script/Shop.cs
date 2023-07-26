using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ColliderHandler coll;
    public Canvas shopCanvas;
    public Button openButton;
    public Button lifeButton;
    public Button speefButton;

    void Start()
    {
        openButton = GetComponent<Button>();
        openButton.onClick.AddListener(shopOpen);
    }

    void shopOpen()
    {
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
