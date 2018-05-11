using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    Interactable inter;
    public bool locked;

    void Start()
    {
        animator = GetComponent<Animator>();
        inter = GetComponentInParent<Interactable>();
    }

    void Update()
    {
        if (inter.inRadius)
        {
            if(locked && Input.GetKeyDown(KeyCode.E))
            {
                locked = !CheckForKey();
            }
            Debug.Log("In Radius");
            if (Input.GetKeyDown(KeyCode.E) && !locked)
            {
                Debug.Log("Interacting");
                animator.SetBool("Open", !animator.GetBool("Open"));
            }
        }
    }

    bool CheckForKey()
    {
        foreach (PickUps i in GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().inventory)
        {
            if (i.name == "Key")
            {
                GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().RemoveItem(i);
                return true;
            }
        }
        return false;
    }

    public void DisableCollider()
    {
        GetComponentInChildren<BoxCollider>().enabled = false;
    }

    public void EnableCollider()
    {
        GetComponentInChildren<BoxCollider>().enabled = true;
    }
}
