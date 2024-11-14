
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{

    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

   


    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void Update()
    {

    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.animator.SetBool(animationHash, false);
    }

 
    protected virtual void AddInputActionsCallbacks()
    {
        PlayerController input = stateMachine.Player.Input;
        stateMachine.Player.Input.playerActions.Attack.performed += OnAttackPerformed;
        stateMachine.Player.Input.playerActions.Attack.canceled += OnAttackCanceled;

    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerController input = stateMachine.Player.Input;
        stateMachine.Player.Input.playerActions.Attack.performed -= OnAttackPerformed;
        stateMachine.Player.Input.playerActions.Attack.canceled -= OnAttackCanceled;


    }
    protected virtual void OnAttackPerformed(InputAction.CallbackContext obj)
    {

        stateMachine.IsAttacking = true;

    }

    protected virtual void OnAttackCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.IsAttacking = false;
    }


    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}