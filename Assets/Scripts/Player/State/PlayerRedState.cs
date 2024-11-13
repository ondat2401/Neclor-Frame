using UnityEngine;

public class PlayerRedState : PlayerState
{
    private float scale;
    public PlayerRedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Red Enter");

        scale = .5f;
        player.moveSpeed += 5;

    }

    public override void Exit()
    {
        base.Exit();
        player.redTrigger = false;
    }

    public override void Update()
    {
        base.Update();

        player.AdjustScale(scale, false);

        if (player.transform.localScale.x <= .5f)
            stateMachine.ChangeState(player.moveState);
    }
}
