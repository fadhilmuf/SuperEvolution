using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool detectPlayer = false;

    void OnTriggerEnter(Collider other) //when object collide to trigger object
    {
        GameObject point = other.gameObject;
        
        switch (other.gameObject.tag)
        {
            case "Player":
                detectPlayer = true;
            break;
            default:
                detectPlayer = false;
            break;
        }
    }
}
