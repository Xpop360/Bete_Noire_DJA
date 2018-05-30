using UnityEngine;

public class PuzzleUIController : MonoBehaviour
{

    Interactable inte;
    GameObject UI;

    void Start()
    {
        inte = GetComponent<Interactable>();
        UI = GameObject.FindGameObjectWithTag("PuzzleUI");
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((inte.inRadius && Input.GetKeyDown(KeyCode.E))) //inRadius pressing E once
        {
            UI.SetActive(!UI.activeSelf);
            if (UI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        if(PauseMenu.gamePause)
        {
            UI.SetActive(false);
        }
    }
}