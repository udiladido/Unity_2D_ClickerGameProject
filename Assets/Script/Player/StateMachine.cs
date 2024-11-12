
using UnityEngine;

public abstract class StateMachine
{
    protected ICharacterStrategy characterStrategy;


    public void ChangeState(ICharacterStrategy character)
    {
        characterStrategy?.Exit();
        characterStrategy = character;
        characterStrategy?.Enter();
    }
    public void Update()
    { 
    
        characterStrategy?.Update();
    
    }

}
