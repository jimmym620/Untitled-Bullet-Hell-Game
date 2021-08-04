using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public Button resumeButton, menuButton, quitButton;

    void Start()
    {

        Button resumeBTN = resumeButton.GetComponent<Button>();
        resumeBTN.onClick.AddListener(Resume);

        Button menuBTN = menuButton.GetComponent<Button>();
        menuBTN.onClick.AddListener(LoadMenu);

        Button quitBTN = quitButton.GetComponent<Button>();
        quitBTN.onClick.AddListener(QuitGame);





    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        UI_SoundManager.Instance.playSelectSound();
    }

    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        GameIsPaused = false;
        UI_SoundManager.Instance.playCancelSound();
        UI_SoundManager.Instance.playMenuMusic();
        UI_SoundManager.Instance.stopL1Music();
    }

    public void QuitGame() 
    {
        UI_SoundManager.Instance.playQuitSound();
        Application.Quit();
    }

}
