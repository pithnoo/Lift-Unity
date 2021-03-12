using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private PlayerController player;
    private AttackDetails attackDetails;
    public float collisionDamage;
    public GameObject deathParticle;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !player.invincible){
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
            
            attackDetails.damageAmount = collisionDamage;

            other.transform.SendMessage("damage", attackDetails);
            Instantiate(deathParticle, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
