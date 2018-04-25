using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform target;

    float clap, speed = 2.0f;
    float maxY, minY;

    Vector3 Look;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Transform>().rotation;
        maxY = 50;
        minY = -90;
    }

    void Update ()
    {
        transform.position = target.position;
        Look = transform.rotation.eulerAngles;

        Look.y += speed * Input.GetAxis("Mouse X");
        Look.x -= speed * Input.GetAxis("Mouse Y");

        clap -= speed * Input.GetAxis("Mouse Y");

        if (clap > maxY)
        {
            clap = maxY;
            Look.x = maxY;
        }
        else if (clap < minY)
        {
            clap = minY;
            Look.x = minY;
        }

        transform.rotation = Quaternion.Euler(Look);
    }
}
