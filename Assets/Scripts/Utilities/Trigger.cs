using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " entered");
        if(other.tag=="PlayerTrigger")
        {
            Debug.Log(enemy.name + " released");
            enemy.SetActive(true);
            GetComponent<AudioSource>().enabled = true;
        }
    }
}
