using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = .2f;
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.attackState);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.throwState);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (stateTimer < 0)
                player.CheckForDashInput();
            else
                player.fx.CreatePopUpText("Sakin ol kral");
        }
    }
}
