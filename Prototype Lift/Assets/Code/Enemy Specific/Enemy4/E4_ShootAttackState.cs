using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_ShootAttackState : ShootAttackState
{
    private Enemy4 enemy;
    public E4_ShootAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_ShootAttack stateData, Enemy4 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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
        stateMachine.ChangeState(enemy.playerDetectedState);
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
