using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, IPooledObject
{

    public Rigidbody2D rb;
    public float scrollSpeed = 1;
    public GameObject passenger, platform;

    public void onObjectSpawn()
    {   
        passenger.SetActive(true);
        gameObject.SetActive(true);
        platform.SetActive(true);

        passenger.transform.parent = gameObject.transform;
        rb.velocity = new Vector2(-scrollSpeed, 0);
    }



    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-scrollSpeed, 0);
        //If off screen
        if ((transform.position.x < -5) || (transform.position.y > 2.5))
        {
            passenger.SetActive(false);
            gameObject.SetActive(false);
            platform.SetActive(false);
            GameControl.instance.platformOnScreen = false; 
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

}
