using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite portalActivated, portalClosed;
    public GameObject portalParticle;
    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        
    }

    public void activatePortal(){
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
