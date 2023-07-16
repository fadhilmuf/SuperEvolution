using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    public ColliderHandler coll;
    private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if(coll.score == 150f)
        {
            virtualCamera.m_Lens.FieldOfView += 30f * Time.deltaTime;
        }
        if(coll.score == 200f)
        {
            virtualCamera.m_Lens.FieldOfView += 50f * Time.deltaTime;
        }
    }
}
