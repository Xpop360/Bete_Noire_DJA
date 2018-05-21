using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOver, gameOverUI;
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameOver.SetActive(true);
        }

        if (GameOverAnimation.end) gameOverUI.SetActive(GameOverAnimation.end);
    }
}
