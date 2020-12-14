using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_PlayerDetectedState : PlayerDetectState
{
    private Enemy2 enemy;
    protected float followSpeed;
    public E2_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.stateData = stateData;
    }
    public override void Enter()
    {
        //entity.SetVelocity(0f);
        base.Enter();
        entity.moveTowardsPlayer(followSpeed);
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
            Debug.Log("not detected");
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        entity.moveTowardsPlayer(4f);
    }
}
