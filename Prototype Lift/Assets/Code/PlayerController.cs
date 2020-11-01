using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space]
    public float moveSpeed = 7f;
    public Rigidbody2D myRigidBody;
    public Vector2 dashDirection;
    public float xRaw, yRaw;
    [Space]
    //private float dashTime = 3.0f; 
    public float dashSpeed = 15f;
    private float dashTime = 0.15f;
    public float dashPause;
    public bool isDashing;
    public int dashCounter = 3;
    private bool isRecharging;


    void Start(){
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //Vector2 dir = new Vector2(movement.x, movement.y); 

        //movement.x = Input.GetAxis("Horizontal");
        //movement.y = Input.GetAxis("Vertical");

        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            dashCounter -= 1;
            DashAbility();
        }
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(xRaw * moveSpeed, yRaw * moveSpeed);
    }

    void DashAbility()
    {
        if (isRecharging)
        {
            return;
        }
        if (isDashing)
        {
            StartCoroutine("Dash");
        }
        if (dashCounter <= 0)
        {
            StartCoroutine("Recharge");
            return;
        }   
    }

    IEnumerator Dash()
    {
        isDashing = false;
        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = 7f;
        yield return new WaitForSeconds(dashPause);
        isDashing = true;
    }

    IEnumerator Recharge()
    {
        Debug.Log("recharge activated");
        isRecharging = true;
        yield return new WaitForSeconds(2);
        dashCounter = 3;
        isRecharging = false;
    }
}
