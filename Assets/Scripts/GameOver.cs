using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOver;
    public Animator animator;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameObject.SetActive(true);
            animator.SetTrigger("gameover");
        }
	}
}
