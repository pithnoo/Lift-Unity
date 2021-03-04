using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_BurstAttackState : BurstAttackState
{
    private Enemy3 enemy;

    public E3_BurstAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_BurstAttack stateData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
        stateMachine.ChangeState(enemy.idleState);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
