using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class passengerBehaviour : Pickup
{
    public GameObject platform, parent;
    private bool moving;
    // Start is called before the first frame update

    void OnEnable()
    {
        moving = true;
        transform.position = new Vector2(platform.transform.position.x, platform.transform.position.y + 0.14f);

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        // if moving then scroll, else fall into player magnet
        if (moving)
        {
            transform.position = new Vector2(platform.transform.position.x, platform.transform.position.y + 0.14f);
        }

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("ItemMagnet"))
        {
            gameObject.transform.parent = null;
            timeStamp = Time.time;
            player = GameObject.FindGameObjectWithTag("Player");
            flyToPlayer = true;
            moving = false;
        }

        // if(other.gameObject.tag == "Player"){
        //     gameObject.SetActive(false);
        //     int collected = GameControl.instance.passsengersCollected++;
        //     UI_SoundManager.Instance.playPassengerCollectedSound();
        // }
    }
}
