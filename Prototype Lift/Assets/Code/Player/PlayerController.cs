using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Space]
    public float moveSpeed = 7f;
    public Rigidbody2D myRigidBody;
    public Vector2 dashDirection;
    public float xRaw, yRaw;
    [Space]
    //private float dashTime = 3.0f; 
    public float dashSpeed = 15f;
    private float dashTime = 0.15f;
    public float dashPause;
    public bool isDashing;
    public int dashCounter = 3;
    private bool isRecharging;
    [Space]
    public Animator animator;
    private Vector2 movement;
    public Crosshair crosshair;
    [Space]
    public ParticleSystem dashParticle;
    public CinemachineImpulseSource source;
    public CinemachineImpulseSource damageSource;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    public DashBar dashBar;
    public float maxCharge = 1;
    public float currentCharge;
    public GameObject playerDeathParticle;
    public bool invincible;
    public Color hurtColour;
    public SpriteRenderer spriteRenderer;
    public LevelManager levelManager;
    public AudioManager audioManager;
 
    void Start(){
        healthBar = FindObjectOfType<HealthBar>();
        dashBar = FindObjectOfType<DashBar>();

        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        crosshair = FindObjectOfType<Crosshair>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();
        //pauseMenu = FindObjectOfType<PauseMenu>();

        healthBar.SetMaxHealth(maxHealth);

        if(PlayerPrefs.HasKey("CurrentHealth") && PlayerPrefs.GetFloat("CurrentHealth") > 0){
            currentHealth = PlayerPrefs.GetFloat("CurrentHealth");
            healthBar.SetHealth(currentHealth);
            Debug.Log("Active");
        }
        else{
            currentHealth = maxHealth;
        }


        currentCharge = maxCharge;
        dashBar.SetCharge(maxCharge);
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //Vector2 dir = new Vector2(movement.x, movement.y); 

        //movement.x = Input.GetAxis("Horizontal");
        //movement.y = Input.GetAxis("Vertical");

        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");
        
        movement = new Vector2(xRaw,yRaw);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            dashCounter -= 1;
            DashAbility();
        }
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(xRaw * moveSpeed, yRaw * moveSpeed);
    }

    void DashAbility()
    {
        if(!PauseMenu.GameIsPaused){
            if (isRecharging)
            {
                return;
            }
            if (isDashing)
            {
                StartCoroutine("Dash");
            }
            if (dashCounter <= 0)
            {
                StartCoroutine("Recharge");
                return;
            }
        }
    }

    IEnumerator Dash()
    {
        invincible = true;
        FindObjectOfType<AudioManager>().Play("Dash");

        animator.SetBool("isDashing",true);
        source.GenerateImpulse();
        dashParticle.Play();

        currentCharge = 0;
        dashBar.SetCharge(currentCharge);
        isDashing = false;

        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = 7f;
        yield return new WaitForSeconds(dashPause);

        isDashing = true;
        animator.SetBool("isDashing",false);

        dashParticle.Stop();

        invincible = false;
    }

    IEnumerator Recharge()
    {
        //Debug.Log("recharge activated");
        isRecharging = true;

        while(currentCharge < maxCharge){
            currentCharge += maxCharge / 100;
            dashBar.SetCharge(currentCharge);
            yield return new WaitForSeconds(0.01f);
        }

        //yield return new WaitForSeconds(1);

        dashCounter = 1;
        isRecharging = false;
    }

    IEnumerator InvincibleTimer(){
        invincible = true;
        yield return new WaitForSeconds(0.05f);
        invincible = false;
    }

    public void damage(AttackDetails attackDetails){
        if(!invincible){

            damageSource.GenerateImpulse();
            StartCoroutine("hitFlash");
            currentHealth -= attackDetails.damageAmount;
            healthBar.SetHealth(currentHealth);

            StartCoroutine("InvincibleTimer");

            if (currentHealth <= 0)
            {
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                FindObjectOfType<AudioManager>().stopPlaying("LevelTheme");
                source.GenerateImpulse();
                Instantiate(playerDeathParticle, transform.position, transform.rotation);
                crosshair.isGameOver = true;
                levelManager.StartCoroutine("gameOver");
                gameObject.SetActive(false);
            }
            else{
                FindObjectOfType<AudioManager>().Play("PlayerHurt");
            }
        }
    }

    IEnumerator hitFlash(){
        spriteRenderer.color = hurtColour;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
}
