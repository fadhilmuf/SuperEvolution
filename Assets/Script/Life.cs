using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public ColliderHandler coll;
    public Button lifeButton;

    void Start()
    {
        lifeButton = GetComponent<Button>();
        lifeButton.onClick.AddListener(LifeConf);
    }

    void LifeConf()
    {
        if(coll.coin >= 3)
        {
            coll.coin -= 3;
            coll.life++;
        }
    }
}
