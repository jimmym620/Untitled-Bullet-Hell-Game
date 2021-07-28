using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;




public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    public Slider volumeSlider;
    public Dropdown GraphicsDropdown, resDropdown;
    public Toggle fullscreenToggle;
    public Button BackButton;
    public GameObject MainMenu;
    public GameObject OptionsMenu;


    Resolution[] resolutions;
    private void Start()
    {
        int currentResolutionIndex = 0;
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Slider volSlider = volumeSlider.GetComponent<Slider>();
        volSlider.onValueChanged.AddListener(delegate { SetVolume(volSlider.value); });

        Dropdown graphicsDropdown = GraphicsDropdown.GetComponent<Dropdown>();
        graphicsDropdown.onValueChanged.AddListener(delegate { SetQuality(graphicsDropdown.value); });

        Toggle fsToggle = fullscreenToggle.GetComponent<Toggle>();
        fsToggle.onValueChanged.AddListener(delegate { SetFullscreen(fsToggle.isOn); });

        Dropdown resolDropdown = resDropdown.GetComponent<Dropdown>();
        resolDropdown.onValueChanged.AddListener(delegate { SetResolution(resolDropdown.value); });

        Button backBTN = BackButton.GetComponent<Button>();
        backBTN.onClick.AddListener(backButtonPressed);
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        UI_SoundManager.Instance.playSelectSound();
    }


    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        UI_SoundManager.Instance.playSelectSound();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        UI_SoundManager.Instance.playSelectSound();
    }

    public void backButtonPressed() 
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        UI_SoundManager.Instance.playCancelSound();
    }
}
