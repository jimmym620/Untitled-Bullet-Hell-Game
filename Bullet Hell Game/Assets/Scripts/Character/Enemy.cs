using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{

    public float health;
    public AudioClip deathSound;
    private bool deathPlayed = false;
    public float moveSpeed = 1;
    public Rigidbody2D rb;
    public float yBoundaries = 1.7f;

    private bool enteredScene;

    public Animator deathAnim;

    void Awake()
    {
        

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
        deathAnim.SetTrigger("Dead");
        // Destroy(gameObject, deathAnim.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        if (!deathPlayed)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            deathPlayed = true;
        }

    }

    void Update()
    {

    }




}
