using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform target;

    float clap, speed = 5.0f;
    float maxY, minY;
    public Vector3 cameraCrouchOffSet = Vector3.zero;

    Vector3 Look;
    GameObject Player;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Player.transform;
        transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Transform>().rotation;
        maxY = 50;
        minY = -90;
    }

    void Update ()
    {
        if(Player.GetComponentInParent<PlayerController>().crouch)
        {
            transform.position = target.position - cameraCrouchOffSet;
        }
        else
        {
            transform.position = target.position;
        }

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

        if (!PauseMenu.gamePause && !SceneController.lost && !SceneController.win && Time.timeScale != 0)
        {
            transform.rotation = Quaternion.Euler(Look);
        }
    }
}
