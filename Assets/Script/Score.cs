using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public ColliderHandler colliderHandler;
    
    public Text coinText;
    public Text highScoreText;
    public Text highScoreSuccesText;
    public TextMeshProUGUI lifetext;
    public TextMeshProUGUI levelText;

    public Slider expSlider;

    public Canvas failedCanvas;

    void Update()
    {
        coinText.text = colliderHandler.coin.ToString();
        
        if(colliderHandler.life == 0)
        {
            Destroy(gameObject);
            failedCanvas.enabled = true;
        }
        lifetext.text = colliderHandler.life.ToString();

        highScoreText.text = colliderHandler.score.ToString();
        highScoreSuccesText.text = colliderHandler.score.ToString();
        levelText.text = colliderHandler.level.ToString();

        if (expSlider.value == expSlider.maxValue)
        {
            expSlider.maxValue *= 1.5f;
            expSlider.value = 0;
            colliderHandler.level++;
        }
    }
}
