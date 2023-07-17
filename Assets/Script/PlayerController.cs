using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
public Camera cam;
public NavMeshAgent agent;

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Ray movePosition = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(movePosition, out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}
