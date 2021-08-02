using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{

    public float health = 100;
    public AudioClip deathSound;
    private bool deathPlayed = false;
    public float moveSpeed = 1;
    public Rigidbody2D rb;
    private float DirY;
    public float yBoundaries = 1.7f;


    public Animator deathAnim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    
        DirY = -1f;
    }

    // If health at 0, enemy dies
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }


    // Update UI displays when enemy dies
    // Destroy the game object on death
    public void Die()
    {
        deathAnim.SetTrigger("Dead");
        Destroy(gameObject, deathAnim.GetCurrentAnimatorStateInfo(0).length);
        gameObject.GetComponent<Collider2D>().enabled = false;
        if(!deathPlayed){
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            rb.velocity = Vector2.zero;
            deathPlayed = true;
        }
    
    }

    void Update() 
    {   

    }

    //Patrolling up and down
    void FixedUpdate() {
        rb.velocity = new Vector2(rb.velocity.x, DirY * moveSpeed );
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Border"){
            DirY *= -1f;
        }
        
    }


}
