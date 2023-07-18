using UnityEngine;
using UnityEngine.UI;

public class ColliderHandler : MonoBehaviour
{
    public float score;
    public Text EvoScore;
    public Movement movement;
    
    void Update()
    {
        //Evolution Score
        EvoScore.text = score.ToString();
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
}
