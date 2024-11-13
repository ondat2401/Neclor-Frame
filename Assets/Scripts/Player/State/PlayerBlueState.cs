using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlueState : PlayerState
{
    public PlayerBlueState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Blue Enter");

        if (!player.IsGrounded())
            rb.velocity = Vector3.zero;

        if(rb.gravityScale > 0)
            rb.AddForce(player.jumpForce * Vector3.up,ForceMode2D.Impulse);
        else
            rb.AddForce(player.jumpForce * Vector3.down, ForceMode2D.Impulse);

    }

    public override void Exit()
    {
        base.Exit();
        player.blueTrigger = false;
    }

    public override void Update()
    {
        base.Update();
        if (player.purpleTrigger)
            stateMachine.ChangeState(player.purpleState);

        if (player.greenTrigger)
            stateMachine.ChangeState(player.greenState);

        if (player.IsGrounded())
            stateMachine.ChangeState(player.moveState);

    }
}
