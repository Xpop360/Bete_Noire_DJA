using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueUI : MonoBehaviour {

    GameObject clueUI;
    Interactable inte;

	// Use this for initialization
	void Start () {
        clueUI = GameObject.FindGameObjectWithTag("Clue");
        clueUI.SetActive(false);
        inte = GetComponent<Interactable>();
	}
	
	// Update is called once per frame
	void Update () {
		if(inte.inRadius && Input.GetKeyDown(KeyCode.E))
        {
            clueUI.SetActive(!clueUI.activeSelf);
            if (clueUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        if (PauseMenu.gamePause)
        {
            clueUI.SetActive(false);
        }
    }
}
