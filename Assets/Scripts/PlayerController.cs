using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Animator animator;
    AnimatorStateInfo state;

    CharacterController player;
    Transform lookAt;

    float FB, LR, yaw, rotationSpeed = 2.0f, speed = 0.1f;

    [HideInInspector]
    public bool crouch = false, running = false, walking = false;

    void Start()
    {
        player = GetComponent<CharacterController>();
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(!EnemyController.lose)
        {
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = !crouch;
            }

            if (Input.GetButton("Vertical"))
            {
                walking = true;
                if (Input.GetButton("Run"))
                {
                    running = true;
                    crouch = false;
                    walking = false;
                }
                else
                {
                    running = false;
                }
            }
            else
            {
                walking = false;
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
            animator.SetFloat("walk", Input.GetAxis("Vertical"));

            LR = speed * Input.GetAxis("Horizontal");
            FB = speed * Input.GetAxis("Vertical");

            yaw = Input.GetAxis("Mouse X") * rotationSpeed;

            Vector3 movement = new Vector3(LR, 0.0f, FB);

            if (!PauseMenu.gamePause) transform.Rotate(new Vector3(0.0f, yaw, 0.0f));

            movement = transform.rotation * movement;

            player.Move(movement * Time.deltaTime);
        }
    }

    void OnAnimatorMove()
    {
        state = animator.GetCurrentAnimatorStateInfo(0);
        if (!state.IsTag("NoMoving"))
        {
            animator.ApplyBuiltinRootMotion();
        }
        else //detected animation tagged NoMoving where we don't want animation movement, doesn't apply movement
        {
            //Debug.Log("No Moving");
        }
    }
}