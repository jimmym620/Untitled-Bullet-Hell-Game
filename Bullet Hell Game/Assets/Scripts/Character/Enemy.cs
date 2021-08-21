using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    public float maxHealth;
    public float health;
    public AudioClip deathSound;
    private bool deathPlayed;
    public float moveSpeed = 1;
    public Rigidbody2D rb;
    public float yBoundaries = 1.7f;

    private bool enteredScene;

    public Animator animator;
    public GameObject deathEffect;


    public virtual void OnDisable()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        deathPlayed = false;

    }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // If health at 0, enemy dies
    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "BorderVertical")
        {
            enteredScene = true;

        }

        // Entered the scene so this enemy cannot go outside of the vertical border
        if ((other.gameObject.tag == "BorderVertical") && enteredScene == true)
        {

            rb.velocity = Vector2.zero;
        }

    }


    // Update UI displays when enemy dies
    // Destroy the game object on death
    public virtual void Die()
    {
        
        // Destroy(gameObject, deathAnim.GetCurrentAnimatorStateInfo(0).length);
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.SetActive(false);
        if (!deathPlayed)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Instantiate(deathEffect, gameObject.transform.position, transform.rotation);

            deathPlayed = true;
        }

    }

    void Update()
    {

    }




}
