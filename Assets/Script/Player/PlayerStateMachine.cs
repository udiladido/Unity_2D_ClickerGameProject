using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }


    public PlayerComboAttackState ComboAttackState { get; }


    public bool IsAttacking { get; set; }
    public int ComboIndex { get; set; }


    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        ComboAttackState = new PlayerComboAttackState(this);
    }

    

}
