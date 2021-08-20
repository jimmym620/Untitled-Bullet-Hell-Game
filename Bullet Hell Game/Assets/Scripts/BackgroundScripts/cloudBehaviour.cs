using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudBehaviour : MonoBehaviour, IPooledObject
{
    private Rigidbody2D rb2d;
    public float scrollSpeed;

    // Start is called before the first frame update
    public void onObjectSpawn()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        // rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
        rb2d.velocity = new Vector2(-scrollSpeed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position.x < -10) || (transform.position.y > 2.5))
        {
            gameObject.SetActive(false);
        }

        // If the game is over, stop scrolling.
        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }

    }


}
