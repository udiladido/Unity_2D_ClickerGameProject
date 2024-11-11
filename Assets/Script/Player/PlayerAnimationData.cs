using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class PlayerAnimationData 
{

    private string HeroKnight_Attack1 = "Attack1";
    private string HeroKnight_Attack2 = "Attack2";
    private string HeroKnight_Attack3 = "Attack3";

    public int HeroKnight_Attack1Hash { get; private set;}
    public int HeroKnight_Attack2Hash { get; private set; }
    public int HeroKnight_Attack3Hash { get; private set; }



    public void Initialize()
    {
        HeroKnight_Attack1Hash = Animator.StringToHash(HeroKnight_Attack1);
        HeroKnight_Attack2Hash = Animator.StringToHash(HeroKnight_Attack2);
        HeroKnight_Attack3Hash = Animator.StringToHash(HeroKnight_Attack3);
       
    }

}
