using UnityEngine;
using UnityEngine.UI;

public class ColliderHandler : MonoBehaviour
{
    float score;
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
                transform.localScale *= 1.01f;
                point.SetActive(false);
                score++;
                Debug.Log(score);
            break;
            case "Speed":
                movement.speed *= 1.2f;
                point.SetActive(false);
                Debug.Log(movement.speed);
            break;
        }
    }
}
