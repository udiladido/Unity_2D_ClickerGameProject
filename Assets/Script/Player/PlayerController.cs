using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public event Action OnTouchEvent;


    public void CallTouchEvent()
    {
        OnTouchEvent?.Invoke();
    }


}
