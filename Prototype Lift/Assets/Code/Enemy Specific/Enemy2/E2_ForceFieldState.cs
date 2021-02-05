using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_ForceFieldState : ForceFieldState
{
    private Enemy2 enemy;
    public E2_ForceFieldState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ForceField stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if(forceFieldSpawned == true){
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
