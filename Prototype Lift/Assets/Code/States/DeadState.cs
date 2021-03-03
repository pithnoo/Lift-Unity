using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeadState : State
{
    protected D_DeadState stateData;
    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        
        GameObject.Instantiate(stateData.deathExplosion, entity.aliveGO.transform.position, entity.aliveGO.transform.rotation);
        stateData.shake();
        entity.gameObject.SetActive(false);
        //entity.enemyDestroyed();
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
    }
}
