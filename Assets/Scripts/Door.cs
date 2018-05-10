using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    Interactable inter;

    void Start()
    {
        animator = GetComponent<Animator>();
        inter = GetComponentInParent<Interactable>();
    }

    void Update()
    {
        if (inter.inRadius)
        {
            Debug.Log("In Radius");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacting");
                animator.SetBool("Open", !animator.GetBool("Open"));
            }
        }
    }
}
