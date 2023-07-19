using UnityEngine;
using UnityEngine.UI;

public class ColliderHandler : MonoBehaviour
{
    public float score;
    public Text EvoScore;
    public Movement movement;

    public Canvas failedCanvas;

    public EnemyController enemy;
    
    void Update()
    {
        //Evolution Score
        EvoScore.text = score.ToString();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            score++;
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
                Debug.Log(score);
                if (score < 210f)
                {
                    transform.localScale *= 1.01f;
                }
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
                else if(score>enemy.scoreEnemy)
                {
                    Destroy(enem);
                }
            break;
        }
    }
}
