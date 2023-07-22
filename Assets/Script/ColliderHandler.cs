using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColliderHandler : MonoBehaviour
{
    //coin
    public float coin;
    public ParticleSystem coinParticle;
    public Text coinText;

    //score
    public float score;
    public float level;
    public Text EvoScore;
    public Text HighScore;
    public TextMeshProUGUI LevelText;

    public Movement movement;

    public Canvas failedCanvas;

    public EnemyController enemy;

    public Slider expSlider;
    private const string CoinKey = "Coins";

    void Start()
    {
        coin = PlayerPrefs.GetFloat(CoinKey, 0f);
    }
    
    void Update()
    {
        //Evolution Score
        coinText.text = coin.ToString();
        EvoScore.text = score.ToString();
        HighScore.text = score.ToString();
        LevelText.text = level.ToString();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            score++;
            expSlider.value++;
        }
        if (expSlider.value == expSlider.maxValue)
        {
            transform.localScale *= 1.1f;
            expSlider.maxValue *= 1.5f;
            expSlider.value = 0;
            level++;
        }
    }
    void OnTriggerEnter(Collider other) //when object collide to trigger object
    {
        GameObject point = other.gameObject;
        
        switch (other.gameObject.tag)
        {
            case "Point":
                Destroy(point);
                score++;
                expSlider.value++;
                Debug.Log(score);
            break;
            case "Speed":
                movement.speed *= 1.2f;
                Destroy(point);
                Debug.Log(movement.speed);
            break;
            case "Coin":
                coin++;
                Destroy(point);
            break;
        }
    }
    void OnCollisionEnter(Collision other) //when object collide to non trigger object
    {
        GameObject enem = other.gameObject;

        switch (other.gameObject.tag)
        {
            case "Enemy":
                if(score<enemy.scoreEnemy)
                {
                    Destroy(gameObject);
                    failedCanvas.enabled = true;
                }
            break;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(CoinKey, coin);
        PlayerPrefs.Save();
    }
}
