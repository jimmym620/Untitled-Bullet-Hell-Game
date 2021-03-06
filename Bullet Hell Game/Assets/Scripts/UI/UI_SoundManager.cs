using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=i0coh71r-v8

public class UI_SoundManager : MonoBehaviour
{
    public AudioSource selectSound, cancelSound, quitSound, menuMusic, L1Music, playerDeathSound, passengerCollected, ResTruckDeath, healthPickup, coinPickup;

    //Singleton
    public static UI_SoundManager Instance = null;
    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu"){
            playMenuMusic();
        }

        

    }

    void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void playSelectSound()
    {
        selectSound.Play();
    }

    public void playCancelSound()
    {
        cancelSound.Play();
    }

    public void playQuitSound()
    {
        quitSound.Play();
    }

    public void playMenuMusic()
    {
        menuMusic.Play();
    }

    public void stopMenuMusic()
    {
        menuMusic.Stop();
    }

    public void playL1Music()
    {
        L1Music.Play();
    }

    public void stopL1Music() 
    {
        L1Music.Stop();
    }

    public void playPlayerDeathSound(){
        playerDeathSound.Play();
    }

    public void playPassengerCollectedSound()
    {
        passengerCollected.Play();
    }

    public void playResTruckDeath() 
    {
        ResTruckDeath.Play();
    }

    public void playHealthPickup()
    {
        healthPickup.Play();
    }

    public void playCoinPickup() 
    {
        coinPickup.Play();
    }

}
