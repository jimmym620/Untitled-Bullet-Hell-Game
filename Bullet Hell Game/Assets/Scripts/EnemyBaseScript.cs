using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{

    public float health = 100f;

    // Take damage when hit by guns - shotgun and smg
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
    void Die()
    {

        Destroy(gameObject);
    }



}
