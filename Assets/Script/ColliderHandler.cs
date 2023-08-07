using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    public int coin;
    public float score, sumScore, level, timer, life = 2;

    public EnemyController enemy;
    public Score sc;
    public PlayerControllerExample player;
    
    private const string CoinKey = "Coins";

    void Start()
    {
        coin = PlayerPrefs.GetInt(CoinKey, 0);
    }
    
    void Update()
    {           
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }

        sumScore = score - enemy.scoreEnemy;
    }
    void OnTriggerEnter(Collider other) //when object collide to trigger object
    {
        GameObject point = other.gameObject;
        
        switch (other.gameObject.tag)
        {
            case "Point":
                Destroy(point);
                score++;
                sc.expSlider.value++;
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
                    timer = 3f;
                }
                if(level>enemy.enemyLevel)
                {
                    Destroy(enem);
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
