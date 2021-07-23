using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 40;

    private float rightSide = 10;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightSide)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        // Enemy enemy = hitInfo.GetComponent<Enemy>();
        // if (enemy != null){
        //     enemy.TakeDamage(damage);
        // }
        IEntity damageable = hitInfo.GetComponent<IEntity>();
        if (damageable != null){
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
        // Instantiate(impactEffect, transform.position, transform.rotation);
        
    }
}
