using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //public static Inventory instance;

    [HideInInspector]
    public List<PickUps> inventory;
    int maxSpace = 3;
    GameObject panels;
    GameObject panel;

    void Start()
    {
        panels = GameObject.FindGameObjectWithTag("InventoryUI");
        inventory = new List<PickUps>();
    }

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        this.tag = "Inventory";
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    DontDestroyOnLoad(gameObject);
    //}

    void Update()
    {

    }

    public void Updateicons()
    {
        int i = 0;
        foreach(PickUps item in inventory)
        {
            panel = panels.GetComponentInChildren<RectTransform>().gameObject.transform.Find("Panel (" + i + ")").GetChild(0).gameObject;
            panel.GetComponent<Image>().sprite = item.icon;
            panel.GetComponent<Image>().enabled = true;
            i++;
        }
        for (int j = i; j < maxSpace; j++)
        {
            panel = panels.GetComponentInChildren<RectTransform>().gameObject.transform.Find("Panel (" + j + ")").GetChild(0).gameObject;
            panel.GetComponent<Image>().enabled = false;
        }
    }

    public bool AddItem(PickUps item)
    {
        if (inventory.Count + 1 <= maxSpace)
        {
            inventory.Add(item);
            Updateicons();
            return true;
        }
        return false;
    }

    public void RemoveItem(PickUps item)
    {
        if(inventory.Contains(item))
        {
            inventory.Remove(item);
            Updateicons();
        }
    }
}