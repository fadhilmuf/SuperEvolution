using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro; 

public class EnemyController : MonoBehaviour
{
    public ColliderHandler coll;
    public Detector detector;
    public ObjectSpawner objectSpawner;

    public NavMeshAgent agent;
    public Light dangerLight;

    public float scoreEnemy, enemyLevel, EnemyStop = 1f;

    public Slider enemySlider;

    public GameObject Player;

    public TextMeshProUGUI enemyLevelText, enemylefttext;

    void Update()
    {   
        FindNearestPointObject();
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log(agent.speed);
        }
        if(enemySlider.value == enemySlider.maxValue)
        {
            enemySlider.value = 0f;
            enemySlider.maxValue *= 1.5f;
            enemyLevel++;
            if (scoreEnemy < 210f)
                {
                    transform.localScale *= 1.01f;
                }
        }
        enemyLevelText.text = enemyLevel.ToString();
    }

    void FindNearestPointObject()
    {
        GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("Point");
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        
        if ((scoreEnemy>coll.score)&&(Player != null)&&(coll.timer < 1f)&&(detector.detectPlayer == true))
        {
            dangerLight.color = Color.gray;
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
            agent.speed = 6f * EnemyStop; // Set the agent's speed to make it run
        }
        else
        {
            dangerLight.color = Color.white;
            if (scoreEnemy<coll.score)
            {
                GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = Color.white;
            }
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
            agent.speed = 2f * EnemyStop; // Set the agent's speed to make it run
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
                enemySlider.value++;
            break;
            case "Speed":
                Destroy(point);
                agent.speed *= 1.1f;
            break;
        }
    }
}
