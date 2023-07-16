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
        float zoomcam = Input.GetAxis("Mouse ScrollWheel");
        if (zoomcam < 0)
        {
            virtualCamera.m_Lens.FieldOfView += 100f * Time.deltaTime;
        }
        if (zoomcam > 0)
        {
            virtualCamera.m_Lens.FieldOfView -= 100f * Time.deltaTime;
        }
    }
}
