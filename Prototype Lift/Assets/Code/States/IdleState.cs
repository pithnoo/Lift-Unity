using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;
    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected float idleTime;
    protected bool isPlayerDetected;
    protected bool isPlayerInRange;
    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        isPlayerDetected = entity.EnemyDetect();
        isPlayerInRange = entity.IsPlayerInRange();
        SetRandomIdleTime();
    }
    public override void Exit()
    {
        base.Exit();

        if(flipAfterIdle){
            entity.flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + idleTime){
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isPlayerDetected = entity.EnemyDetect();
    }

    public void SetFlipAfterIdle(bool flip){
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime(){
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
