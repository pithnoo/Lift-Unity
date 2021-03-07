using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage = 10f;
    private AttackDetails attackDetails;
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Player"){

            attackDetails.damageAmount = damage;
            collision.transform.SendMessage("damage", attackDetails);
        }
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
