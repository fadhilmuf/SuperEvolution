using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    public int coin;
    public float score, level, timer, life = 2;

    public EnemyController enemy;
    public Score sc;
    public PlayerControllerExample player;
    public ObjectSpawner objectSpawner;
    
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
        }
        //Cheat key
        if(Input.GetMouseButtonDown(0))
        {
            score++;
            sc.expSlider.value++;
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
                else if(score>enemy.scoreEnemy)
                {
                    Destroy(enem);
                    objectSpawner.enemydecrease++;
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
