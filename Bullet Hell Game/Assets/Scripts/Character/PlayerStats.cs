using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IEntity
{
    public float maxHealth;
    public float health;
    public Text HP_Display;

    // public AudioClip playerDeathSound;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void addHealth(float amount)
    {
        if (health < maxHealth)
        {
            health += amount;
        } else{
            health = maxHealth;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Display.text = "Health \n" + health;
        if(health > maxHealth){
            health = maxHealth;
        }
    }

    public void Die()
    {
        // AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        UI_SoundManager.Instance.playPlayerDeathSound();
        Destroy(gameObject);
        // wait(((int)playerDeathSound.length));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        UI_SoundManager.Instance.stopL1Music();
        Time.timeScale = 0;
        GameControl.instance.GameOver();

    }

    IEnumerator wait(int value)
    {

        yield return new WaitForSeconds(value);
    }

}
