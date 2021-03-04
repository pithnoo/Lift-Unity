using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Entity
{
    public E3_IdleState idleState { get ; private set; }
    public E3_BurstAttackState burstAttackState { get; private set; } 
    public E3_PlayerDetectedState playerDetectedState { get; private set; }
    public E3_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_BurstAttack burstAttackData;
    [SerializeField]
    private Transform burstAttackPosition;

    public override void Start(){
        base.Start();

        idleState = new E3_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E3_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        deadState = new E3_DeadState(this, stateMachine, "dead", deadStateData, this);
        burstAttackState = new E3_BurstAttackState(this, stateMachine, "burstAttack", burstAttackPosition, burstAttackData, this);


        stateMachine.Initialise(idleState);
    }

    public override void damage(AttackDetails attackDetails)
    {
        base.damage(attackDetails);

        if(isDead){
            stateMachine.ChangeState(deadState);
        }
    }
}
