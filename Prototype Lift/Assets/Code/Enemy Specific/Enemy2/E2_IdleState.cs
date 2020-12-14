using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_IdleState : IdleState
{
    private Enemy2 enemy;
    public E2_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }
    public override void Enter()
    {
        //entity.SetVelocity(0f);
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
            Debug.Log("detected");
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
