using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public int facingDirection { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    public Transform target;
    private Vector2 velocityWorkspace;
    private bool facingRight;

    public virtual void Start(){
        facingDirection = 1;

        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update(){
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate(){
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity){
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall(){
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool EnemyDetect(){
        return Physics2D.OverlapCircle(playerCheck.position, entityData.playerCheckDistance, entityData.whatIsPlayer);
    }

    public virtual void moveTowardsPlayer(float velocity){
        transform.position = Vector2.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
              
        if(target.position.x > transform.position.x){
            transform.localScale = new Vector3(1,1,1);
        }
        else if(target.position.x < transform.position.x){
            transform.localScale = new Vector3(-1,1,1);
        }
    }


    public virtual void flip(){
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos() {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
    }
}
