using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2f;
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x,0,z);
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }

}
