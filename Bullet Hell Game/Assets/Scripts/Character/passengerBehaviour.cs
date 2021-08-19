using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class passengerBehaviour : Pickup
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if(other.gameObject.tag == "Player"){
            gameObject.SetActive(false);
            int collected = GameControl.instance.passsengersCollected++;
            UI_SoundManager.Instance.playPassengerCollectedSound();
        }
    }
}
