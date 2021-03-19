using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gun : MonoBehaviour
{
    //public CinemachineImpulseSource source;
    public float bulletSpeed;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public Animator animator;
    public AudioManager audioManager;
    public string gunSound;

    void Start() {
        animator = GetComponent<Animator>();
        //audioManager = FindObjectOfType<AudioManager>();
    }

    public void fireBullet(Vector2 direction, float rotationZ){
        if (Time.time >= nextTimeToFire)
        {
            FindObjectOfType<AudioManager>().Play(gunSound);

            nextTimeToFire = Time.time + 1f/fireRate;
            GameObject b = Instantiate(bulletPrefab) as GameObject;

            b.transform.position = firePoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            //source.GenerateImpulse();
            animator.SetTrigger("Shoot");
            //CameraShaker.Instance.ShakeOnce(1f, 1f, .1f, 1f);
        }
        
    }
}
