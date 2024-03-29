﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Vector3 target;
    //public GameObject crosshair;
    public GameObject weapon;

    //public GameObject bulletPrefab;
    //public GameObject firePoint;

    public GameObject player;
    public Vector3 difference;
    public float bulletSpeed;
    public float rotationZ;
    public Gun gun;
    public PauseMenu pauseMenu;

    public bool isRotated = true;
    public bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>();
        Cursor.visible = true;
        PauseMenu.GameIsPaused = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));      
        difference = target - weapon.transform.position;   

        if(!PauseMenu.GameIsPaused){
            if (Input.GetMouseButton(0) && !isGameOver)
            {
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();

                gun.fireBullet(direction, rotationZ);
            }

            if (target.x > player.transform.position.x)
            {
                isRotated = true;
                weapon.transform.localScale = new Vector3(1, 1, 1);
                player.transform.localScale = new Vector3(2, 2, 1);
            }
            else if (target.x < player.transform.position.x)
            {
                isRotated = false;
                weapon.transform.localScale = new Vector3(-1, -1, 1);
                player.transform.localScale = new Vector3(-2, 2, 1);
            }
        }
        
    }

    void FixedUpdate() {
        //crosshair.transform.position = new Vector2(target.x, target.y);
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    public void resetGun(){
        gun = FindObjectOfType<Gun>();
    }
}
