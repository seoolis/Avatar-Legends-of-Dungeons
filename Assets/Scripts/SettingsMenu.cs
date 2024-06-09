using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    private Resolution[] resolutions;
    private int currentResolutionIndex;
    private bool isFullscreen;
    private float volume;

    void Start()
    {
        LoadSettings();

        resolutions = Screen.resolutions;

        if (resolutions == null || resolutions.Length == 0)
            return;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        fullscreenToggle.isOn = Screen.fullScreen;

        volumeSlider.value = volume;
        if (audioMixer != null)
        {
            audioMixer.SetFloat("MasterVolume", volume);
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutions == null || resolutionIndex < 0 || resolutionIndex >= resolutions.Length)
            return;

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume)
    {
        if (audioMixer != null)
        {
            float dB = Mathf.Lerp(-80, 0, volume);
            audioMixer.SetFloat("MasterVolume", dB);
        }
    }

    public void SaveSettings()
    {
        currentResolutionIndex = resolutionDropdown.value;
        isFullscreen = fullscreenToggle.isOn;
        volume = volumeSlider.value;

        PlayerPrefs.SetInt("ResolutionIndex", currentResolutionIndex);
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1 ? true : false;
        volume = PlayerPrefs.GetFloat("Volume", 1.0f);

        resolutionDropdown.value = currentResolutionIndex;
        fullscreenToggle.isOn = isFullscreen;
        volumeSlider.value = volume;

        SetResolution(currentResolutionIndex);
    }
}
