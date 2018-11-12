using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMTrigger : MonoBehaviour {

    public GameObject UI;

    public void AnimationComplete()
    {
        UI.SetActive(true);
    }
}
