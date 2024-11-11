using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
  {

    public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }


    private void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();

    }
}
