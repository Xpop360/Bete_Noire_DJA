using UnityEngine;

public class GameOverAnimation : MonoBehaviour {

    public Animator animator;
    public static bool end = false;

    void Update()
    {
        animator.SetTrigger("gameover");
    }

    public void AnimationComplete()
    {
        end = true;
    }
}
