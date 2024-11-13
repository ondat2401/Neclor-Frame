using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.blueTrigger)
        {
            stateMachine.ChangeState(player.blueState);
            return;
        }

        if (player.yellowTrigger)
        {
            stateMachine.ChangeState(player.yellowState);
            return;
        }

        if (player.redTrigger)
        {
            stateMachine.ChangeState(player.redState);
            return;
        }

        if (player.orangeTrigger)
        {
            stateMachine.ChangeState(player.orangeState);
            return;
        }

        if (player.purpleTrigger)
        {
            stateMachine.ChangeState(player.purpleState);
            return;
        }

        if (player.greenTrigger)
        {
            stateMachine.ChangeState(player.greenState);
            return;
        }
    }
}
