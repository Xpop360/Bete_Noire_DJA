using UnityEngine;

public class GameOverAnimation : MonoBehaviour {

    public Animator animator;
    public static bool end = false;

    void Update()
    {
        animator.SetTrigger("FadeIn");
    }

    public void AnimationComplete()
    {
        end = true;
        Time.timeScale = 0;
    }
}
