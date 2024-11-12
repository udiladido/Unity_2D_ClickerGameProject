using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData 
{

    [SerializeField] private string attackParameterName = "Attack";
    [SerializeField] private string ComboAttackParameterName = "ComboAttack";


    public int AttackParameterHash { get; private set;}

    public int ComboAttackParameterHash { get; private set; }


    public void Initialize()
    {
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        ComboAttackParameterHash = Animator.StringToHash(ComboAttackParameterName);
    
       
    }

}
