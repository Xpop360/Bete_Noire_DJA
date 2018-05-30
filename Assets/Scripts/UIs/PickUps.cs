using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public string name;
    public Sprite icon;
    
    Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if (GetComponent<Interactable>().inRadius)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inventory.AddItem(this))
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
