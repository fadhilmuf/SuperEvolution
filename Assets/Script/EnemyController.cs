using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public ColliderHandler coll;
    public NavMeshAgent agent;

    public Text enemyScore;
    public float scoreEnemy;

    public GameObject Player;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        enemyScore.text = scoreEnemy.ToString();
        
        FindNearestPointObject();
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log(agent.speed);
        }
    }

    void FindNearestPointObject()
    {
        GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("Point");
        GameObject[] speedObjects = GameObject.FindGameObjectsWithTag("Speed");
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        
        if ((scoreEnemy > coll.score)&&(Player == true))
        {
            audioSource.Play();
            GetComponent<MeshRenderer>().material.color = Color.red;
            GameObject nearestObject = playerObjects[0];
            float nearestDistance = Vector3.Distance(transform.position, nearestObject.transform.position);

            for (int i = 1; i < playerObjects.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, pointObjects[i].transform.position);

                if (distance < nearestDistance)
                {
                    nearestObject = playerObjects[i];
                    nearestDistance = distance;
                }
            }

            agent.SetDestination(nearestObject.transform.position);
            agent.speed = 6f; // Set the agent's speed to make it run
        }
        else
        {
            audioSource.Stop();
            GetComponent<MeshRenderer>().material.color = Color.white;
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
            case "Speed":
                Destroy(point);
                agent.speed *= 1.1f;
            break;
        }
    }
}
