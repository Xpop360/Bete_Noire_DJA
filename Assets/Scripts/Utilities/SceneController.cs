using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    public static bool lost, win;
    public static int level;

    public GameObject text, gameOverUI;

    // Use this for initialization
    void Start () {
        lost = false;
        win = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(lost || win)
        {
            if (lost)
            {
                text.GetComponent<Text>().text = "game over";
                text.GetComponent<Text>().color = Color.red;
            }
            if (win)
            {
                text.GetComponent<Text>().text = "a winner is you";
                text.GetComponent<Text>().color = Color.green;
            }

            text.SetActive(true);
            gameOverUI.SetActive(GameOverAnimation.end);
        }
	}

    public static void LoadLevel1()
    {
        SceneManager.LoadScene("Map1");
        SoundController.StopAll();
        SoundController.Play("Thunder");
        level = 1;
    }

    //Põe aki o gameover! antes do que ja esta
    public static void GameOver()
    {
        SoundController.StopAll();
        SoundController.Play("Lost");
        level = 0;
    }
}
