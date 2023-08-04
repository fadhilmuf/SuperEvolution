using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColliderHandler : MonoBehaviour
{
    //coin
    public int coin;

    //score
    public float score;
    public float sumScore;
    public float level;

    //life
    public float life = 2;

    private Movement movement;

    public Canvas failedCanvas;
    public Canvas EvoCard;

    public EnemyController enemy;
    private PlayerControllerExample player;

    
    private const string CoinKey = "Coins";

    void Start()
    {
        coin = PlayerPrefs.GetInt(CoinKey, 0);
    }
    
    void Update()
    {           
        
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
