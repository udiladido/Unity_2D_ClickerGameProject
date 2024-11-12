using System;
using UnityEngine;


[SerializeField]
public class PlayerAttackData
{

    [field: Range(0f, 25f)] public float AttackSpeed { get; private set; } = 1f;
    [field: Range(0f, 25f)] public float AttackDamage { get; private set; } = 5f;



}
