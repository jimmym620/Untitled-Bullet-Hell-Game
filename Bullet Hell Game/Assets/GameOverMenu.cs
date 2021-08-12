using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    GameCanvas pauseMenu;
    public Button menuButton, quitButton;
    // Start is called before the first frame update
    void Start()
    {
        Button menuBTN = menuButton.GetComponent<Button>();
        menuBTN.onClick.AddListener(pauseMenu.LoadMenu);

        Button quitBTN = quitButton.GetComponent<Button>();
        quitBTN.onClick.AddListener(pauseMenu.QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
