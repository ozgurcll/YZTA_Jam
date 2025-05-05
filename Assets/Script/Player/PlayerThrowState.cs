using UnityEngine;

public class PlayerThrowState : PlayerState
{
    public PlayerThrowState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (xInput != 0)
            player.SetVelocity(player.moveSpeed * .5f * xInput, rb.linearVelocityY);

        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
}
