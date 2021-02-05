using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage = 5f;
    private AttackDetails attackDetails;
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Enemy"){
            attackDetails.damageAmount = damage;
            collision.transform.parent.SendMessage("damage", attackDetails);
        }

        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
