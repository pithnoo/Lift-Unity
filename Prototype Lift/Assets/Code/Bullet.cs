using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage = 5f;
    private AttackDetails attackDetails;
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Target"){
            Target target = collision.transform.GetComponent<Target>();
            target.TakeDamage(damage);
        }
        else if(collision.tag == "Enemy"){
            attackDetails.damageAmount = damage;
            collision.transform.parent.SendMessage("damage", attackDetails);
        }
        else{
            FindObjectOfType<AudioManager>().Play("BulletCollision");
        }
        
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
