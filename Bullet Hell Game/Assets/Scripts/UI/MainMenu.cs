using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton, QuitButton, OptionsButton;
    public GameObject OptionsMenu;

    void Start()
    {
        Button playBTN = PlayButton.GetComponent<Button>();
        playBTN.onClick.AddListener(PlayGame);

        Button quitBTN = QuitButton.GetComponent<Button>();
        quitBTN.onClick.AddListener(QuitGame);


        GameObject optionsMenu = OptionsMenu.GetComponent<GameObject>();

        Button optionsBTN = OptionsButton.GetComponent<Button>();
        optionsBTN.onClick.AddListener(ShowOptionsMenu);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UI_SoundManager.Instance.stopMenuMusic();
        UI_SoundManager.Instance.playSelectSound();

    }

    public void QuitGame()
    {
        UI_SoundManager.Instance.playQuitSound();
        Application.Quit();
    }

    public void ShowOptionsMenu() 
    {
        OptionsMenu.SetActive(true);
        transform.gameObject.SetActive(false);
        UI_SoundManager.Instance.playSelectSound();
    }
}
