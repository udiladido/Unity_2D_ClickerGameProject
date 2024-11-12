using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
  {

    [field :Header("Animations")]
    [field : SerializeField] public PlayerAnimationData animationData { get; private set; }

    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }


    private PlayerStateMachine stateMachine;

    public Animator animator { get; private set; }

    public PlayerController Input { get; private set; }


    private void Awake()
    {
      
        animationData.Initialize();
        animator = GetComponent<Animator>();
        Input = GetComponent<PlayerController>();

        stateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
       stateMachine.Update();

    }

}
