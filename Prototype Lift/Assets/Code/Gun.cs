using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletSpeed;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public void fireBullet(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(bulletPrefab) as GameObject;

        b.transform.position = firePoint.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        CinemachineShake.Instance.ShakeCamera(.5f, .1f);
    }
}
