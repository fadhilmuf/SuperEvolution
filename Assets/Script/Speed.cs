using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public ColliderHandler coll;
    public Movement move;
    public Button speedButton;

    void Start()
    {
        speedButton = GetComponent<Button>();
        speedButton.onClick.AddListener(SpeedConf);
    }

    void SpeedConf()
    {
        if(coll.coin >= 2)
        {
            coll.coin -= 2;
            move.speed += 1;
        }
    }
}
