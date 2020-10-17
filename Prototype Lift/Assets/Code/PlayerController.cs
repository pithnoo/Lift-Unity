using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D myRigidBody;
    public Vector2 movement;
    public float xRaw, yRaw;
    public float rotationZ;
    private float dashTime; 
    public float dashSpeed = 50.0f;


    void Start(){
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");

        //Vector2 dir = new Vector2(movement.x, movement.y); 

        if(Input.GetKeyDown("space")){
            if(xRaw != 0 || yRaw != 0){
                Dash(xRaw, yRaw);
                Debug.Log("active");
            }
        }
    }

    void FixedUpdate(){
        myRigidBody.velocity = new Vector2(xRaw * moveSpeed, yRaw * moveSpeed);
        //myRigidBody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);  
    }
    private void Dash(float x, float y){
        myRigidBody.velocity = Vector2.zero;
        myRigidBody.velocity += new Vector2(x,y).normalized * dashSpeed;
    }
}
