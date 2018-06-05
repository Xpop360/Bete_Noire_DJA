using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Animator animator;
    AnimatorStateInfo state;

    CharacterController player;
    Transform lookAt;

    bool onceFootsteps, oncerunning;

    float FB, LR, yaw, rotationSpeed = 2.0f, speed = 0.1f;

    int walk = 0;

    [HideInInspector]
    public bool crouch = false, running = false, walking = false;

    void Start()
    {
        player = GetComponent<CharacterController>();
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        onceFootsteps = true;
        oncerunning = true;
    }

    void Update()
    {
        if (!SceneController.lost)
        {
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = !crouch;
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                if (Input.GetButton("Run"))
                {
                    walk = 2;
                    crouch = false;
                }
                else
                {
                    walk = 1;
                }
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                walk = -1;
            }
            else
            {
                walk = 0;
            }

            //if (Input.GetButton("Vertical"))
            //{
            //    walking = true;
            //    if (Input.GetButton("Run"))
            //    {
            //        running = true;
            //        crouch = false;
            //        walking = false;
            //    }
            //    else
            //    {
            //        running = false;
            //    }
            //}
            //else
            //{
            //    walking = false;
            //}

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

            //animator.SetBool("isRunning", running);
            animator.SetBool("isCrouching", crouch);
            //animator.SetBool("isWalking", walking);            

            animator.SetInteger("walk", walk);

            LR = speed * Input.GetAxis("Horizontal");
            FB = speed * Input.GetAxis("Vertical");

            yaw = Input.GetAxis("Mouse X") * rotationSpeed;

            Vector3 movement = new Vector3(LR, 0.0f, FB);

            if (!PauseMenu.gamePause) transform.Rotate(new Vector3(0.0f, yaw, 0.0f));

            movement = transform.rotation * movement;

            player.Move(movement * Time.deltaTime);

            //sounds
            //walking
            if ((walk == 1 || walk == -1) && Time.timeScale != 0)
            {
                if (onceFootsteps)
                {
                    SoundController.Play("Footsteps1");
                    onceFootsteps = false;
                }
            }
            else
            {
                onceFootsteps = true;
                SoundController.Stop("Footsteps1");
            }
            //running
            if ((walk == 2) && Time.timeScale != 0)
            {
                if (oncerunning)
                {
                    SoundController.Play("Running3");
                    oncerunning = false;
                }
            }
            else
            {
                oncerunning = true;
                SoundController.Stop("Running3");
            }
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