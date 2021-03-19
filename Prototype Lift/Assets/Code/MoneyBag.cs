using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Color hurtColour;

    // Start is called before the first frame update
    void Start()
    {
        //myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet"){
            StartCoroutine("hitFlash");
        }
    }

    public IEnumerator hitFlash(){
        spriteRenderer.color = hurtColour;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
}
