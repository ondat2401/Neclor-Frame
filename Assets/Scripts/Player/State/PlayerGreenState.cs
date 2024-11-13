using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreenState : PlayerState
{
    public PlayerGreenState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Green Enter");
        rb.velocity = Vector3.zero;

        rb.gravityScale *= -1;

        player.transform.localEulerAngles += new Vector3(0, 180f, 180f);

        player.SetFacingDefault();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!player.greenTrigger)
            stateMachine.ChangeState(player.moveState);
    }
}
