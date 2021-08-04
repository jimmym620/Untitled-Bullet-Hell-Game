using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IEntity
{
    public float health = 100;
    public Text HP_Display;
    // public AudioClip playerDeathSound;



    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Debug.Log("dead");
            Die();
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

    public void Die(){
        // AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        UI_SoundManager.Instance.playPlayerDeathSound();
        Destroy(gameObject);
        // wait(((int)playerDeathSound.length));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies){
            GameObject.Destroy(enemy);
        }
        UI_SoundManager.Instance.stopL1Music();
        Time.timeScale = 0;

    }

    IEnumerator wait(int value){

        yield return new WaitForSeconds(value);
    }
}
