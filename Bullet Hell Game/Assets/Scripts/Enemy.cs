using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{

    public float health = 100;
    public AudioClip deathSound;

    public Animator deathAnim;

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
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

}
