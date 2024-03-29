using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_IdleState : IdleState
{
    private Enemy4 enemy;
    public E4_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy4 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isPlayerDetected){
            stateMachine.ChangeState(enemy.playerDetectedState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        entity.lookTowardsPlayer();
    }

}
