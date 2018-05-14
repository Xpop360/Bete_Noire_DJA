using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " entered");
        if(other.tag=="PlayerTrigger")
        {
            enemy.SetActive(true);
            GetComponent<AudioSource>().enabled = true;
        }
    }
}
