using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTutorial : MonoBehaviour {

    public GameObject tutorial;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerTrigger")
        {
            Destroy(tutorial);
            Destroy(this.gameObject);
        }
    }
}
