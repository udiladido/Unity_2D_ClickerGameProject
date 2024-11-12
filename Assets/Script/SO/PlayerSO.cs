using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BasePlayer", menuName = "Characters/BasePlayer")]
public class PlayerSO : ScriptableObject
{
   
    public PlayerAttackData AttackData { get; private set; }

}
