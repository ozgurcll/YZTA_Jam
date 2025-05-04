using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.fx.HitStopEffect(.1f, .1f);
        stateTimer = player.dashDuration;

        player.stats.MakeInvincible(true);

    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.linearVelocityY);

        player.stats.MakeInvincible(false);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);

    }
}
