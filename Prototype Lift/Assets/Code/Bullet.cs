using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    void OnTriggerEnter2D(Collider2D collision){
        Destroy(gameObject);
    }
}
