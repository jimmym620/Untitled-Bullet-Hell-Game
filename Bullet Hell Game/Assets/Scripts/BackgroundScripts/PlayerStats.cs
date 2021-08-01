using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IEntity
{
    public float health = 100;
    public Text HP_Display;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Debug.Log("dead");
            // Die();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP_Display.text = "Health \n" + health;
    }

    void Die(float SecondsToWait){
        Destroy(gameObject, SecondsToWait);
    }
}
