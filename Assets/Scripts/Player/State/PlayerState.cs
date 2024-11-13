using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;


    protected Rigidbody2D rb;
    protected Animator anim;

    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        anim = player.anim;
        rb = player.rb;

        player.anim.SetBool(animBoolName, true);
        triggerCalled = false;

    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        player.Movement();
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
        stateTimer = 0;
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
