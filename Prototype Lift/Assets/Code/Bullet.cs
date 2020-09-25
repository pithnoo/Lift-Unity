using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    void OnCollsionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}
