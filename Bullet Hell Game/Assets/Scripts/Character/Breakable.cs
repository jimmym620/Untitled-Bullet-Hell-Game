using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable :MonoBehaviour, IEntity
{
    public float health;
    public float moveSpeed = 1;

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
