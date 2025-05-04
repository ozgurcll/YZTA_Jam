using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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


        if (player.IsGroundDetected())
        {
            player.fx.PlayDustFX();
            stateMachine.ChangeState(player.idleState);
        }
        if (xInput != 0)
            player.SetVelocity(player.moveSpeed * .8f * xInput, rb.linearVelocityY);

            
        if (Input.GetKeyDown(KeyCode.Mouse1))
            stateMachine.ChangeState(player.throwState);
        if(Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.attackState);
    }
}
