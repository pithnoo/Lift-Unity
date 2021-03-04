using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Entity
{
    public E5_IdleState idleState {get; private set;}
    public E5_PlayerDetectedState playerDetectedState {get; private set;}
    public E5_DeadState deadState {get; private set;}

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_DeadState deadStateData;

    public override void Start(){
        base.Start();

        idleState = new E5_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E5_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        deadState = new E5_DeadState(this, stateMachine, "dead", deadStateData, this);


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
