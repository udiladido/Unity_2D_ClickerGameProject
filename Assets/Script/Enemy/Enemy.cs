using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth health { get; private set; }

    public Animator animator { get; private set; }

    private void Awake()
    {
       
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        health.OnDie += OnDie;
    }

    void OnDie()
    {
        animator.SetTrigger("IsDead");

    }


}
