using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;

    // public float scrollSpeed = -1.5f;
    public GameObject gameOverMenuUI, waveOverUI;
    public bool waveIsOver; //is set to true in SpawnerL script
    public int numOfWaves;
    public int currentWave;

    public int passsengersCollected =0;
    public Text passCollectedText;
    public bool platformOnScreen;       //check if a platform is currently on the screen

    public bool gameOver = false;
    public bool waveScreenActive = false;
    bool nextWaveStarting = false;
    

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        passCollectedText.text = passsengersCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (waveIsOver == true  && gameOver == false && waveScreenActive == false && nextWaveStarting == false)
        {
            waveComplete();
        }

        passCollectedText.text = "Passengers Collected: " + passsengersCollected;

        
    }

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        
    }

    public void waveComplete()
    {
        waveOverUI.SetActive(true);
        waveScreenActive = true;
        Invoke("waveCompleteHide", 5f);

    }

    public void waveCompleteHide()
    {
        waveOverUI.SetActive(false);
        waveIsOver = false;
        nextWaveStarting = true;
    }
}
