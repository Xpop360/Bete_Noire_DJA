using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject text, gameOverUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            text.GetComponent<Text>().text = "game over";
            text.GetComponent<Text>().color = Color.red;

            text.SetActive(true);
        }

        gameOverUI.SetActive(GameOverAnimation.end);
    }
}
