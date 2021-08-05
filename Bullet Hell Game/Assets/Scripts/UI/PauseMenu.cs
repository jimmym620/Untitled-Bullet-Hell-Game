using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI, gameOverMenuUI;

    public Button resumeButton, menuButton, quitButton, restartButton;
    public Button GO_menuButton, GO_quitButton, GO_restartButton;

    Scene currentScene;
    string sceneName;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        

        Button resumeBTN = resumeButton.GetComponent<Button>();
        resumeBTN.onClick.AddListener(Resume);

        Button menuBTN = menuButton.GetComponent<Button>();
        menuBTN.onClick.AddListener(LoadMenu);

        Button quitBTN = quitButton.GetComponent<Button>();
        quitBTN.onClick.AddListener(QuitGame);

        Button restartBTN = restartButton.GetComponent<Button>();
        restartButton.onClick.AddListener(RestartGame);

        Button GO_menuBTN = GO_menuButton.GetComponent<Button>();
        GO_menuButton.onClick.AddListener(LoadMenu);

        Button GO_quitBTN = GO_quitButton.GetComponent<Button>();
        GO_quitButton.onClick.AddListener(QuitGame);

        Button GO_restartBTN = GO_restartButton.GetComponent<Button>();
        GO_restartButton.onClick.AddListener(RestartGame);



    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
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

    public void GameOver()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        UI_SoundManager.Instance.playQuitSound();
        Application.Quit();
    }

}
