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

    // Start is called before the first frame update
    void Start()
    {
        objectHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage){
        StartCoroutine("hitFlash");
        objectHealth -= damage;

        if(objectHealth <= 0){
            Destroy(gameObject);
            transform.parent.SendMessage("forceFieldBroken");
            Instantiate(deathParticle, transform.position, transform.rotation);
            
        }
    }

    public IEnumerator hitFlash(){
        spriteRenderer.color = damageColour;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
}
