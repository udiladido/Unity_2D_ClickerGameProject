using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Player Player { get; }

    public Worrior WorriorState { get; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

    }

}
