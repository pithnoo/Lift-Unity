using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRotation : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > transform.position.x){
            transform.localScale = new Vector3(1,1,1);
        }
        else if(target.position.x < transform.position.x){
            transform.localScale = new Vector3(-1,1,1);
        }
    }
}
