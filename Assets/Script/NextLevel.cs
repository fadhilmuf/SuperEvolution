using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextLevel : MonoBehaviour
{
    public Button nextLevel;
    public TextMeshProUGUI levelText;

    int level = 1;

    void Start()
    {
        nextLevel.onClick.AddListener(Levelling);
    }

    // Update is called once per frame
    void Levelling()
    {
        level++;
        levelText.text = "Level " + level.ToString();
    }
}
