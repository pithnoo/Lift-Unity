using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelPortal : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite portalActivated, portalClosed;
    public GameObject portalParticle;
    public GameObject portalUI;
    public bool isActivated;
    public bool isWithPlayer;
    public LayerMask whatIsPlayer;
    public float detectionRadius;
    public Animator animator;
    public GameObject spawningParticle;
    public PlayerController playerController;
    public CinemachineImpulseSource source;
    public bool soundPlayed;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        soundPlayed = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update() {
        isWithPlayer = Physics2D.OverlapCircle(transform.position, detectionRadius, whatIsPlayer);
        if(isWithPlayer && isActivated){

            portalUI.SetActive(true);

            if(!playerController.isDashing){
                playerController.gameObject.SetActive(false);

                Instantiate(playerController.playerDeathParticle, transform.position, transform.rotation);
                FindObjectOfType<AudioManager>().Play("PortalWarp");

                animator.SetBool("isActivated", false);
                portalParticle.SetActive(false);
                
                source.GenerateImpulse();
            }
        }
        else{
            portalUI.SetActive(false);
        }
    }

    public void activatePortal(){
        if(!soundPlayed){
            FindObjectOfType<AudioManager>().Play("PortalOpen");
            soundPlayed = true;
        }
        animator.SetBool("isSpawning", false);
        isActivated = true;
        animator.SetBool("isActivated", true);
        //spriteRenderer.sprite = portalActivated;
        portalParticle.SetActive(true);
    }

    public void closePortal(){
        isActivated = false;
        animator.SetBool("isActivated", false);
        //spriteRenderer.sprite = portalClosed;
        portalParticle.SetActive(false);
    }

    public void spawningEnemies(){
        FindObjectOfType<AudioManager>().Play("PortalSpawning");
        animator.SetBool("isSpawning", true);
        Instantiate(spawningParticle, transform.position, transform.rotation);
    }

    public void stopSpawning(){
        animator.SetBool("isSpawning", false);
    }

}
