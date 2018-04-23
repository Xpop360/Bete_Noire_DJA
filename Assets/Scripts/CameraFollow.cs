using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform target;

    float clap, speed = 2.0f;

    Vector3 Look;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Transform>().rotation;
    }

    void Update ()
    {
        transform.position = target.position;
        Look = transform.rotation.eulerAngles;

        Look.y += speed * Input.GetAxis("Mouse X");
        Look.x -= speed * Input.GetAxis("Mouse Y");

        clap -= speed * Input.GetAxis("Mouse Y");

        if (clap > 90)
        {
            clap = 90;
            Look.x = 90;
        }
        else if (clap < -90)
        {
            clap = -90;
            Look.x = 270;
        }

        transform.rotation = Quaternion.Euler(Look);
    }
}
