using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectionPoint : MonoBehaviour
{
    private GameObject player;
    // private string[] PickupTypes = { "Pickup", "HealthKit" };

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Pickup"))
        {
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.tag.Equals("Coin"))
        {
            other.gameObject.SetActive(false);
            GameControl.instance.coinsCollected++;
            UI_SoundManager.Instance.playCoinPickup();
        }

        if (other.gameObject.tag.Equals("HealthKit"))
        {
            other.gameObject.SetActive(false);
            player.GetComponent<PlayerStats>().addHealth(other.GetComponent<HealthKit>().HP_Value);
            UI_SoundManager.Instance.playHealthPickup();
        }

        if(other.gameObject.name.Equals("passenger_blue"))
        {
            int collected = GameControl.instance.passsengersCollected++;
            UI_SoundManager.Instance.playPassengerCollectedSound();
        }
    }
}
