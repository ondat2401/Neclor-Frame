using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPurpleState : PlayerState
{
    public PlayerPurpleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Purple Enter");
        rb.AddForce(player.dashForce * Vector3.right * player.moveDir,ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!player.purpleTrigger)
            stateMachine.ChangeState(player.moveState);
    }
}
