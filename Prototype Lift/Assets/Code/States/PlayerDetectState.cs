using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectState : State
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerDetected;
    public PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
    public override void Enter()
    {
        base.Enter();
        isPlayerDetected = entity.EnemyDetect();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        isPlayerDetected = entity.EnemyDetect();

    }

}
