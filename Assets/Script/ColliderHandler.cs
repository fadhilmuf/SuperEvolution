using UnityEngine;
using UnityEngine.UI;

public class ColliderHandler : MonoBehaviour
{
    public float score;
    public Text EvoScore;
    public Text HighScore;
    public Movement movement;

    public Canvas failedCanvas;

    public EnemyController enemy;

    public Slider expSlider;
    private const string ScoreKey = "PlayerScore";

    void Start()
    {
        score = PlayerPrefs.GetFloat(ScoreKey, 0f);
    }
    
    void Update()
    {
        //Evolution Score
        EvoScore.text = score.ToString();
        HighScore.text = score.ToString();

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
        PlayerPrefs.SetFloat(ScoreKey, score);
        PlayerPrefs.Save();
    }
}
