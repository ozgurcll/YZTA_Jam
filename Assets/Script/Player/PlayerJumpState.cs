using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(rb.linearVelocityX, player.jumpForce);
        player.fx.PlayDustFX();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (xInput != 0)
            player.SetVelocity(player.moveSpeed * .8f * xInput, rb.linearVelocityY);
        if (rb.linearVelocityY < 0)
            stateMachine.ChangeState(player.airState);
        if(Input.GetKeyDown(KeyCode.Mouse1))
            stateMachine.ChangeState(player.throwState);

    }
}
