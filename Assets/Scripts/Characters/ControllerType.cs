using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerType : MonoBehaviour {

    public static string horizontal, vertical;

    public static string lookHorizontal, lookVertical;

    public static string run, crouch;

    public static string interact, confirm, cancel, pause, flashlight;

    public void Start()
    {
        Keyboard();
    }

    void Keyboard()
    {
        horizontal = "HorizontalKb";
        vertical = "VerticalKb";
        lookHorizontal = "LookXKb";
        lookVertical = "LookYKb";
        run = "RunKb";
        crouch = "CrouchKb";
        interact = "InteractKb";
        confirm = "ConfirmKb";
        cancel = "CancelKb";
        pause = "PauseKb";
        flashlight = "FlashlightKb";
    }

    void Joystick()
    {
        horizontal = "HorizontalJ";
        vertical = "VerticalJ";
        lookHorizontal = "LookXJ";
        lookVertical = "LookYJ";
        run = "RunJ";
        crouch = "CrouchJ";
        interact = "InteractJ";
        confirm = "ConfirmJ";
        cancel = "CancelJ";
        pause = "PauseJ";
        flashlight = "FlashlightJ";
    }
}
