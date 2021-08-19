using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : Pickup, IPooledObject
{
    //Bouncing variables
    private Rigidbody2D rb_;
    public float force = 5;
    Vector3 lastVelocity;

    public void onObjectSpawn()
    {
        Start();
    }

    // Start is called before the first frame update
    public override void Start()
    {   
        base.Start();
        rb_ = GetComponent<Rigidbody2D>();
        rb_.AddForce(new Vector2(9.8f * force, 9.8f * force));
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

}

//https://www.youtube.com/watch?v=RoZG5RARGF0