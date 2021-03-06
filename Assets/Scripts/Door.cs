﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    Interactable inter;
    public bool locked;
    Inventory inv;
    AudioSource a;

    void Start()
    {
        animator = GetComponent<Animator>();
        inter = GetComponentInParent<Interactable>();
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        a = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (inter.inRadius)
        {
            if(locked && Input.GetKeyDown(KeyCode.E))
            {
                locked = !CheckForKey();
            }
            if (Input.GetKeyDown(KeyCode.E) && !locked)
            {
                animator.SetBool("Open", !animator.GetBool("Open"));
            }
        }
    }

    bool CheckForKey()
    {
        foreach (PickUps i in inv.inventory)
        {
            if (i.name == "Key")
            {
                inv.RemoveItem(i);
                inv.Updateicons();
                return true;
            }
        }
        return false;
    }

    public void DisableCollider()
    {
        GetComponentInChildren<BoxCollider>().enabled = false;
        a.enabled = false;
        a.enabled = true;
        
    }

    public void EnableCollider()
    {
        GetComponentInChildren<BoxCollider>().enabled = true;
    }
}
