﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : IEntity
{
    public float health = 100;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {

            // Die();
        }
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
