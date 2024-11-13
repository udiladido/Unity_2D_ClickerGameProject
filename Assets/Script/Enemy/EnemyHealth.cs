using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public event Action OnDie;
    private int health;
    public bool IsDead => health == 0;


    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health - damage, 0);

        if (health == 0) OnDie?.Invoke();


    }



}
