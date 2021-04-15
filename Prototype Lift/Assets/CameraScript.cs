using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, Time.deltaTime);
    }
}
