using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private ICharacterStrategy characterState;

    public event Action OnTouchEvent;


    public void CallTouchEvent()
    {
        OnTouchEvent?.Invoke();
    }

    public void ChangeCharacter(ICharacterStrategy character)
    {

        characterState = character;

    }
    

    

}
