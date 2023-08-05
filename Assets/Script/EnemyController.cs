using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro; 

public class EnemyController : MonoBehaviour
{
    public ColliderHandler coll;
    public Detector detector;

    public NavMeshAgent agent;
    public Light dangerLight;

    public float scoreEnemy;
    public float EnemyStop = 1f;
    public float enemyLevel; 

    public Slider enemySlider;

    public GameObject Player;
    public GameObject detectorObject;

    public TextMeshProUGUI enemyLevelText;

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
            enemySlider.maxValue *= 1.2f;
            enemyLevel++;
            if (scoreEnemy < 210f)
                {
                    transform.localScale *= 1.01f;
                    detectorObject.transform.localScale *= 1.01f;
                }
        }
        enemyLevelText.text = enemyLevel.ToString();
    }

    void FindNearestPointObject()
    {
        GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("Point");
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        
        if ((coll.sumScore < 0)&&(Player != null)&&(detector.detectPlayer == true)&&(coll.timer < 1f))
        {
            dangerLight.intensity = 0.1f;
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
            dangerLight.intensity = 1f;
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
