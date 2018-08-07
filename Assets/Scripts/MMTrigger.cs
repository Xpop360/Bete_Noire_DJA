using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMTrigger : MonoBehaviour {

    public static bool end = false;

    public void AnimationComplete()
    {
        end = true;
    }
}
