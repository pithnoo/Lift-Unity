using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttackState : AttackState
{
    protected D_ShootAttack stateData;
    protected GameObject projectile;
    protected Vector3 difference;
    public ShootAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_ShootAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
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

        fireProjectile();
    }
    public void fireProjectile(){
        projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);

        difference = entity.target.transform.position - projectile.transform.position;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;

        projectile.GetComponent<Rigidbody2D>().velocity = direction * stateData.moveSpeed;
    }
}
