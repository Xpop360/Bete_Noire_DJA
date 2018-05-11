using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gamePause = false;
    public GameObject pauseMenuUI;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
	}

    void Pause()
    {
        gamePause = true;
        pauseMenuUI.SetActive(gamePause);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        gamePause = false;
        pauseMenuUI.SetActive(gamePause);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("QUIT!!!");
    }
}
