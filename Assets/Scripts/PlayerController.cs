using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Animator animator;

    CharacterController player;

    float FB, LR, yaw, rotationSpeed = 2.0f, speed = 0.1f;

    bool crouch = false, running = false, walking = false;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        LR = speed * Input.GetAxis("Horizontal");
        FB = speed * Input.GetAxis("Vertical");

        yaw = Input.GetAxis("Mouse X") * rotationSpeed;

        Vector3 movement = new Vector3(LR, 0.0f, FB);

        transform.Rotate(new Vector3(0.0f, yaw, 0.0f));
        
        movement = transform.rotation * movement;

        player.Move(movement * Time.deltaTime);

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = !crouch;
        }

        if (Input.GetAxis("Vertical") > 0 && !Input.GetButton("Run"))
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        if (Input.GetButton("Run"))
        {
            running = true;
            crouch = false;
        }
        else
        {
            running = false;
        }

        if (crouch == true)
        {
            GetComponent<CharacterController>().center = new Vector3(0, 0.5f, 0);
            GetComponent<CharacterController>().height = 1f;
        }
        else
        {
            GetComponent<CharacterController>().center = new Vector3(0, 0.9f, 0);
            GetComponent<CharacterController>().height = 1.9f;
        }

        animator.SetBool("isRunning", running);
        animator.SetBool("isCrouching", crouch);
        animator.SetBool("isWalking", walking);
    }
}