using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOver, gameOverUI;
    public Animator animator;

    void Update()
    {
        if (SceneController.lost)
        {
            gameOver.SetActive(SceneController.lost);
        }

        if (GameOverAnimation.end) gameOverUI.SetActive(GameOverAnimation.end);
    }
}
