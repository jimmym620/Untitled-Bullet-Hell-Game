using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : Pickup
{
    //Bouncing variables
    private Rigidbody2D rb_;
    public float force = 5;
    public float HP_Value = 30;
    Vector3 lastVelocity;



    // Start is called before the first frame update
    public override void onObjectSpawn()
    {   
        base.onObjectSpawn();
        rb_ = GetComponent<Rigidbody2D>();
        rb_.AddForce(new Vector2(getDirection() * force, getDirection() * force));
        
    }

    float getDirection()
    {
        float direction = Random.Range(0, 2) == 0 ? -9.8f : 9.8f;
        return direction;
    }

    // Update is called once per frame
    public override void Update()
    {   
        base.Update();
        lastVelocity = rb_.velocity;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Bounce around the screen
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.GetContact(0).normal);

        rb_.velocity = direction * Mathf.Max(speed, 0f);


    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    public float giveHealth(){
        return HP_Value;

    }
}

//https://www.youtube.com/watch?v=RoZG5RARGF0