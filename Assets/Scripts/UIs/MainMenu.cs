using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject title, buttons;

    public void Update()
    {
        title.gameObject.SetActive(true);
        buttons.SetActive(MMTrigger.end);
    }

    public void StartGame()
    {
        SceneController.LoadLevel1();
    }

    public void Close()
    {
        Application.Quit();
    }
}
