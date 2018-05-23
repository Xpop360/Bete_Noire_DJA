using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOver, gameOverUI;
    public Animator animator;

    void Update()
    {
        if (EnemyController.lose)
        {
            gameOver.SetActive(EnemyController.lose);
        }

        if (GameOverAnimation.end) gameOverUI.SetActive(GameOverAnimation.end);
    }
}
