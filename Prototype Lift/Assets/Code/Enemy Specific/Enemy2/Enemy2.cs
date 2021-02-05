using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    public E2_IdleState idleState {get; private set;}
    public E2_PlayerDetectedState playerDetectedState {get; private set;}
    public E2_DeadState deadState {get; private set;}
    public E2_ForceFieldState forceFieldState {get; private set;}

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_ForceField forceFieldStateData;

    public override void Start(){
        base.Start();

        idleState = new E2_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E2_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        deadState = new E2_DeadState(this, stateMachine, "dead", deadStateData, this);
        forceFieldState = new E2_ForceFieldState(this, stateMachine, "forceField", forceFieldStateData, this);


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
