using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxHealth;
    public float objectHealth;
    public Color damageColour;
    private SpriteRenderer spriteRenderer;
    public GameObject deathParticle;
    public float collisionDamage;
    public PlayerController playerController;
    private AttackDetails attackDetails;

    // Start is called before the first frame update
    void Start()
    {
        objectHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void TakeDamage(float damage){
        StartCoroutine("hitFlash");
        objectHealth -= damage;

        if(objectHealth <= 0){
            Destroy(gameObject);
            transform.parent.SendMessage("forceFieldBroken");
            Instantiate(deathParticle, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("FieldBroken");
        }
    }

    public IEnumerator hitFlash(){
        spriteRenderer.color = damageColour;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !playerController.invincible){

            attackDetails.damageAmount = collisionDamage;
            transform.parent.SendMessage("forceFieldBroken"); //FIXES INVINCIBLITY

            other.transform.SendMessage("damage", attackDetails);
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
