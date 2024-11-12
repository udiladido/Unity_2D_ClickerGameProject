
using UnityEngine;



[SerializeField]
public class EnemyAnimationData
{
    private string Enemy_Hurt = "Hurt";
    private string Enemy_Death= "Death";
   

    public int Enemy_HurtHash { get; private set; }
    public int Enemy_DeathHash { get; private set; }
    public int HeroKnight_Attack3Hash { get; private set; }



    public void Initialize()
    {
        Enemy_HurtHash = Animator.StringToHash(Enemy_Hurt);
        Enemy_DeathHash = Animator.StringToHash(Enemy_Death);


    }
}
