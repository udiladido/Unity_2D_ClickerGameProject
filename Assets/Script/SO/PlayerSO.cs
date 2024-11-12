using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class AttackInfoData
{

    [field: SerializeField] public string AttackName { get; private set; }
    [field: SerializeField] public int ComboStateIndex { get; private set; }

    [field: SerializeField][field : Range(0f, 25f)] public float AttackSpeed { get; private set; } = 1f;

    [field: SerializeField] public int Damage;

  

    [field: SerializeField][field: Range(0f, 1f)] public float ComboTransitionTime { get; private set; }

}

[Serializable]

public class PlayerAttackData
{

    [field: SerializeField] public List<AttackInfoData> AttackInfoDatas { get; private set; }
    public int GetAttackInfoCount() { return AttackInfoDatas.Count; }
    public AttackInfoData GetAttackInfo(int index) { return AttackInfoDatas[index]; }


}


[CreateAssetMenu(fileName = "BasePlayer", menuName = "Characters/BasePlayer")]
public class PlayerSO : ScriptableObject
{
   
   [field: SerializeField] public PlayerAttackData AttackData { get; private set; }
  

}
