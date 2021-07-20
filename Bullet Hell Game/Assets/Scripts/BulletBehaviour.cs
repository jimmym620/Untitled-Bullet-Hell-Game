using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;

    private float rightSide = 30;


    // public GameObject impactEffect;

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
        EnemyBaseScript enemy = hitInfo.GetComponent<EnemyBaseScript>();
        if (enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        // Instantiate(impactEffect, transform.position, transform.rotation);
        
    }
}
