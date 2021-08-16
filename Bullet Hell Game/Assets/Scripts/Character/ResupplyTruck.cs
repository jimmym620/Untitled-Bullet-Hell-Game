using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResupplyTruck : Breakable
{
    ObjectPooler objectPooler;
    public bool enteredScene;
    public float speed = 1;

    private float DirX;


    // Start is called before the first frame update
    void Start()
    {
        DirX = 1f;
        objectPooler = ObjectPooler.Instance;



        // rb.velocity = new Vector2(-DirX, 0);
    }

    private void OnEnable() {
        gameObject.GetComponent<Collider2D>().enabled = true;
        enteredScene = false;

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (enteredScene == true && other.gameObject.tag == "BorderVertical")
            {
                DirX *= -1f;
            }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "BorderVertical"){
            enteredScene = true;
        }
    }

    public float getDirectionX()
    {
        return DirX;
    }

    IEnumerator wait(int sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
