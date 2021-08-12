using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float scrollSpeed;
    public GameObject passenger;
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(-scrollSpeed, 0);
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-scrollSpeed, 0);

        if ((transform.position.x < -5) || (transform.position.y > 2.5))
        {
            gameObject.SetActive(false);
            GameControl.instance.platformOnScreen = false; 
            passenger.SetActive(true);
        }

        if(transform.position.x <= 2 && transform.position.x >=-2)
        {
            GameControl.instance.platformOnScreen = true;
        }

        // If the game is over, stop scrolling.
        if (GameControl.instance.gameOver == true)
        {
            rb.velocity = Vector2.zero;
        }

    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            // other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

}
