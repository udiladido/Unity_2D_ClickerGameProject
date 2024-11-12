
using UnityEngine;

public class PlayerBaseState : MonoBehaviour
{
  
    PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.animator.SetBool(animationHash, false);
    }

}
