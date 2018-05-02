using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius;
    public GameObject player;
    [HideInInspector]
    public bool inRadius;
    float distance;

    void Start()
    {
        radius = 0.3f;
        inRadius = false;
        Debug.Log(player);
    }

    void Update()
    {
        Debug.Log(player);
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < radius)
        {
            inRadius = true;
        }
        else
        {
            inRadius = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
