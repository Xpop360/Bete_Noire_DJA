using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour {

    public void LoadScene1()
    {
        SceneManager.LoadScene("Map1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
