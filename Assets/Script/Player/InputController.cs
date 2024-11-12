using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : PlayerController
{

    public void OnTouch(InputValue value)
    {

        CallTouchEvent();

    }

}
