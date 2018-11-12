using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    Animator a;

    public GameObject mainTitle, mainButtons;

    private void Start()
    {
        a = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        mainTitle.SetActive(true);
    }

    public void StartGame()
    {
        SceneController.LoadLevel1();
    }

    public void Options()
    {
        mainTitle.SetActive(false);
    }

    public void Close()
    {
        Application.Quit();
    }
}
