using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Rigidbody2D rb;
    float timeStamp;
    GameObject player;
    bool flyToPlayer;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public virtual void Update()
    {
        // Fly towards player
        if (flyToPlayer)
        {
            playerDirection = -(transform.position - player.transform.position).normalized;
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * 5f * (Time.time / timeStamp);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("ItemMagnet"))
        {
            timeStamp = Time.time;
            player = GameObject.FindGameObjectWithTag("Player");
            flyToPlayer = true;
            // gameObject.transform.parent = null;
        }
    }
}
