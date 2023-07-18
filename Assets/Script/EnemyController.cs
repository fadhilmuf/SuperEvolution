using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public ColliderHandler coll;
    public NavMeshAgent agent;

    public Text enemyScore;
    public float scoreEnemy;

    void Update()
    {
        enemyScore.text = scoreEnemy.ToString();
        
        FindNearestPointObject();
    }

    void FindNearestPointObject()
    {
        GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("Point");

        if (pointObjects.Length > 0)
        {
            GameObject nearestObject = pointObjects[0];
            float nearestDistance = Vector3.Distance(transform.position, nearestObject.transform.position);

            for (int i = 1; i < pointObjects.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, pointObjects[i].transform.position);

                if (distance < nearestDistance)
                {
                    nearestObject = pointObjects[i];
                    nearestDistance = distance;
                }
            }

            agent.SetDestination(nearestObject.transform.position);
            agent.speed = 2f; // Set the agent's speed to make it run
        }
    }

    void OnTriggerEnter(Collider other) //when object collide to trigger object
    {
        GameObject point = other.gameObject;
        
        switch (other.gameObject.tag)
        {
            case "Point":
                Destroy(point);
                scoreEnemy++;
                Debug.Log(scoreEnemy);
                if (scoreEnemy < 210f)
                {
                    transform.localScale *= 1.01f;
                }
            break;
        }
    }
    void OnCollisionEnter(Collision other) //when object collide to non trigger object
    {
        GameObject player = other.gameObject;

        switch (other.gameObject.tag)
        {
            case "Player":
                if(scoreEnemy<coll.score)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(player);
                }
            break;
        }
    }
}
