using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldState : State
{
    protected D_ForceField stateData;
    protected bool isPlayerDetected;
    protected bool forceFieldSpawned = false;
    public ForceFieldState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ForceField stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        GameObject enemyField = GameObject.Instantiate(stateData.forceField, entity.transform.position, entity.transform.rotation);
        
        enemyField.transform.parent = entity.transform;

        forceFieldSpawned = true;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        isPlayerDetected = entity.EnemyDetect();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
}
