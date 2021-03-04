using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAttackState : AttackState
{
    protected D_BurstAttack stateData;

    public BurstAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_BurstAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
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

        SpawnProjectiles(stateData.numberOfProjectiles);
    }

    public void SpawnProjectiles(int numProjectiles){
        float angleStep = 360f / numProjectiles;
		float angle = 0f;

		for (int i = 0; i <= stateData.numberOfProjectiles - 1; i++) {
			
			float projectileDirXposition = attackPosition.position.x + Mathf.Sin ((angle * Mathf.PI) / 180) * stateData.radius;
			float projectileDirYposition = attackPosition.position.y + Mathf.Cos ((angle * Mathf.PI) / 180) * stateData.radius;

			Vector3 projectileVector = new Vector3 (projectileDirXposition, projectileDirYposition, 0f);
			Vector3 projectileMoveDirection = (projectileVector - attackPosition.position).normalized * stateData.moveSpeed;

			var proj = GameObject.Instantiate (stateData.projectile, attackPosition.position, Quaternion.identity);
            proj.transform.Rotate(0, 0, angle);
			proj.GetComponent<Rigidbody2D> ().velocity = 
				new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}
    }   
}
