using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_PlayerDetectedState : PlayerDetectState
{
    private Enemy4 enemy;
    public E4_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy4 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(isPlayerInRange){
            stateMachine.ChangeState(enemy.shootState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        entity.lookTowardsPlayer();
        entity.moveTowardsPlayer(stateData.followSpeed);
    }

}
