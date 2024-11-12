using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegacy : MonoBehaviour
{


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void EnemyOnClick()
    {
        anim.SetTrigger("Hit");
    
    }

}
