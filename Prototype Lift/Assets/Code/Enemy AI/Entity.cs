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
    public AnimationToStateMachine atsm { get; private set; }
    [SerializeField]
    private Transform playerInRange;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    public Transform target;
    private Vector2 velocityWorkspace;
    public float currentHealth;
    protected bool isDead;
    public bool invincible;
    public Color hurtColour;
    public SpriteRenderer spriteRenderer;
    public GameObject[] AI;
    public float SpaceBetween;
    public LevelManager levelManager;
    public virtual void Start(){
        currentHealth = entityData.maxHealth;
        facingDirection = 1;
        invincible = false;

        AI = GameObject.FindGameObjectsWithTag("Enemy");

        aliveGO = transform.Find("Alive").gameObject;
        spriteRenderer = aliveGO.GetComponent<SpriteRenderer>();
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();
        atsm = aliveGO.GetComponent<AnimationToStateMachine>();
        levelManager = FindObjectOfType<LevelManager>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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

    public virtual bool IsPlayerInRange(){
        return Physics2D.OverlapCircle(playerInRange.position, entityData.playerAttackDistance, entityData.whatIsPlayer);
    }

    public virtual void moveTowardsPlayer(float velocity){

        foreach(GameObject go in AI){
            float distance = Vector3.Distance(go.transform.position, aliveGO.transform.position);

            if(distance <= SpaceBetween){
                Vector3 direction = aliveGO.transform.position - go.transform.position;
                transform.Translate(direction * Time.deltaTime);
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
    }

    public virtual void lookTowardsPlayer(){
        if(target.position.x > transform.position.x){
            transform.localScale = new Vector3(1,1,1);
        }
        else if(target.position.x < transform.position.x){
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    public virtual void damage(AttackDetails attackDetails){
        if(!invincible){
            StartCoroutine("hitFlash");
            currentHealth -= attackDetails.damageAmount;
            if (currentHealth <= 0)
            {
                isDead = true;
            }
        }
    }


    public virtual void enemyDestroyed(){
        Destroy(gameObject);
    }

    public virtual void flip(){
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos() {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
    }

    public IEnumerator hitFlash(){
        spriteRenderer.color = hurtColour;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
}
