using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomb : MonoBehaviour
{

    [Header("Projectile Properties")]
    public int numberOfProjectiles;
    public GameObject projectile;
    public float bulletTime;
    private float moveSpeed;
    public GameObject bulletExplosion;
    private float radius;
    private Vector2 startPoint;



    // Start is called before the first frame update
    void Start()
    {
        radius = 100f;
        moveSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTime -= Time.deltaTime;

        if(bulletTime <= 0f){
            explode();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            explode();
            Destroy(gameObject);
        }
    }

    public void explode(){
        //Instantiate(bulletExplosion, transform.position, transform.rotation);   
        startPoint = transform.position;
        SpawnProjectiles(numberOfProjectiles);
    }

    public void SpawnProjectiles(int numProjectiles){
        float angleStep = 360f / numProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++) {
			
			float projectileDirXposition = startPoint.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2 (projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate (projectile, startPoint, Quaternion.identity);
            proj.transform.Rotate(0, 0, angle);
			proj.GetComponent<Rigidbody2D> ().velocity = 
				new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}
    }    
}
