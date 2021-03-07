using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private float rotationZ;
    private GameObject player;
    private Vector3 target;
    private Vector3 difference;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
        difference = target - transform.position;
    }
    void FixedUpdate() {
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(player.transform.position.x > transform.position.x){
            transform.localScale = new Vector3(1,1,1);
        }
        else if(player.transform.position.x < transform.position.x){
            transform.localScale = new Vector3(-1,-1,1);
        }
    }
}
