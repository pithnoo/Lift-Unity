using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_PlayerDetectedState : PlayerDetectState
{
    private Enemy3 enemy;
    public E3_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        entity.lookTowardsPlayer();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isPlayerDetected){
            stateMachine.ChangeState(enemy.idleState);
        }
        else if(Time.time >= startTime + pauseTime){
            stateMachine.ChangeState(enemy.burstAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        entity.lookTowardsPlayer();
        entity.moveTowardsPlayer(stateData.followSpeed);
    }

}
