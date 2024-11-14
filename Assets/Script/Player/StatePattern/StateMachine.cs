
using UnityEngine;

public abstract class StateMachine
{
    protected IState currentState;


    public void ChangeState(IState character)
    {
        currentState?.Exit();
        currentState = character;
        currentState?.Enter();
    }
    public void Update()
    {

        currentState?.Update();
    
    }



}
