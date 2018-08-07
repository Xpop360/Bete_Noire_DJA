using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gamePause = false;
    public GameObject pauseMenuUI;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) && !SceneController.lost && !SceneController.win)
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        pauseMenuUI.SetActive(gamePause);
    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        gamePause = true;        
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gamePause = false;
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
