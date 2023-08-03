using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 3f;
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Jump");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x,y,z);
        if (movement.magnitude > 1f)    
        {
            movement.Normalize();
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
