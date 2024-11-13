using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYellowState : PlayerState
{
    private float scale;

    public PlayerYellowState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Yellow Enter");
        scale = 1.5f;

        if(player.moveSpeed>5)
            player.moveSpeed -= 5;
    }

    public override void Exit()
    {
        base.Exit();
        player.yellowTrigger = false;
    }

    public override void Update()
    {
        base.Update();
        player.AdjustScale(scale, true);

        if (player.transform.localScale.x >= 1.5f)
            stateMachine.ChangeState(player.moveState);

    }
}
