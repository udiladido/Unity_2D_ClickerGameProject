using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData 
{

    [SerializeField] private string Player_Attack1 = "Attack1";
    [SerializeField] private string Player_Attack2 = "Attack2";
    [SerializeField] private string Player_Attack3 = "Attack3";

    public int Player_Attack1Hash { get; private set;}
    public int Player_Attack2Hash { get; private set; }
    public int Player_Attack3Hash { get; private set; }



    public void Initialize()
    {
        Player_Attack1Hash = Animator.StringToHash(Player_Attack1);
        Player_Attack2Hash = Animator.StringToHash(Player_Attack2);
        Player_Attack3Hash = Animator.StringToHash(Player_Attack3);
       
    }

}
