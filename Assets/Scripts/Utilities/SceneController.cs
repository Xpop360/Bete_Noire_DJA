using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static bool lost;

	// Use this for initialization
	void Start () {
        lost = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(lost)
        {
            SceneManager.LoadScene("LostMenu");
        }
	}
}
