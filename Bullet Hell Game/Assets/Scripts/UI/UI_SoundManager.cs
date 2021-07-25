using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=i0coh71r-v8

public class UI_SoundManager : MonoBehaviour
{
    public AudioSource selectSound, cancelSound, quitSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static UI_SoundManager instance = null;
    public static UI_SoundManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
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
}
