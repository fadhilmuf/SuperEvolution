using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColliderHandler : MonoBehaviour
{
    public ParticleSystem runParticle;
    //coin
    public int coin;
    public Text coinText;

    //score
    public float score;
    public float sumScore;
    public float level;
    public Text EvoScore;
    public Text HighScore;
    public TextMeshProUGUI LevelText;
    public Text SpeedtText;

    public float life;
    public Text lifetext;

    public Movement movement;

    public Canvas failedCanvas;
    public Canvas EvoCard;

    public EnemyController enemy;
    public PlayerControllerExample player;

    public Slider expSlider;
    private const string CoinKey = "Coins";

    void Start()
    {
        coin = PlayerPrefs.GetInt(CoinKey, 0);
    }
    
    void Update()
    {
        runParticle.Play();
        
        SpeedtText.text = player.playerSpeed.ToString();
        
        if(life == 0)
        {
            Destroy(gameObject);
            failedCanvas.enabled = true;
        }
        lifetext.text = life.ToString();
        
        Debug.Log(score - enemy.scoreEnemy);
        sumScore = score - enemy.scoreEnemy;
        EvoScore.text = sumScore.ToString();

        //Evolution Score
        coinText.text = coin.ToString();
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
                    life--;
                    score = enemy.scoreEnemy;
                }
            break;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(CoinKey, coin);
        PlayerPrefs.Save();
    }
}
