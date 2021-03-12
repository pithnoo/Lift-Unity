using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        isWithPlayer = Physics2D.OverlapCircle(transform.position, detectionRadius, whatIsPlayer);
        if(isWithPlayer && isActivated){
            portalUI.SetActive(true);
        }
        else{
            portalUI.SetActive(false);
        }
    }

    public void activatePortal(){
        FindObjectOfType<AudioManager>().Play("PortalOpen");
        isActivated = true;
        spriteRenderer.sprite = portalActivated;
        portalParticle.SetActive(true);
    }

    public void closePortal(){
        isActivated = false;
        spriteRenderer.sprite = portalClosed;
        portalParticle.SetActive(false);
    }

}
