using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static bool lost;
    public static bool win;
    public static int level;

	// Use this for initialization
	void Start () {
        lost = false;
        win = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(lost)
        {
            SceneManager.LoadScene("LostMenu");
        }
        if(win)
        {

        }
	}

    public static void LoadLevel1()
    {
        SceneManager.LoadScene("Map1");
        SoundController.StopAll();
        SoundController.Play("Thunder");
        level = 1;
    }
}
