using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Entity
{
    public E4_IdleState idleState { get ; private set; }
    public E4_PlayerDetectedState playerDetectedState { get; private set; }
    public E4_DeadState deadState { get; private set; }
    public E4_ShootAttackState shootState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_ShootAttack shootAttackData;
    [SerializeField]
    private Transform shootAttackPosition;

    public override void Start(){
        base.Start();

        idleState = new E4_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E4_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        deadState = new E4_DeadState(this, stateMachine, "dead", deadStateData, this);
        shootState = new E4_ShootAttackState(this, stateMachine, "shootAttack", shootAttackPosition, shootAttackData, this);


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
