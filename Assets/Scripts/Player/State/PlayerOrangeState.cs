using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrangeState : PlayerState
{
    public PlayerOrangeState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Orange Enter");

        player.moveDir *= -1;

        player.transform.localEulerAngles += new Vector3(0, 180f, 0);
        
        player.SetFacingDefault();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!player.orangeTrigger)
            stateMachine.ChangeState(player.moveState);

    }
}
