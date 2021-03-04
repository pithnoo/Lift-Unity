using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_PlayerDetectedState : PlayerDetectState
{
    private Enemy5 enemy;
    private bool forceFieldActivated = false;
    public E5_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy5 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.stateData = stateData;
    }
    public override void Enter()
    {
        //entity.SetVelocity(0f);
        base.Enter();
        entity.lookTowardsPlayer();
        //entity.moveTowardsPlayer(stateData.followSpeed);
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
        entity.lookTowardsPlayer();
        entity.moveTowardsPlayer(stateData.followSpeed);
    }
}
