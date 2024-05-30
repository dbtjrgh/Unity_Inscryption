using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainAudioMixer;

    private int masterVolume = 3;
    private int musicVolume = 3;
    private int sfxVolume = 3;
    private const int maxVolume = 6;
    private const int minVolume = 1;

    void Start()
    {
        UpdateVolumes();
    }

    public void IncreaseMasterVolume()
    {
        masterVolume = Mathf.Clamp(masterVolume + 1, minVolume, maxVolume);
        UpdateVolumes();
    }

    public void DecreaseMasterVolume()
    {
        masterVolume = Mathf.Clamp(masterVolume - 1, minVolume, maxVolume);
        UpdateVolumes();
    }

    public void IncreaseMusicVolume()
    {
        musicVolume = Mathf.Clamp(musicVolume + 1, minVolume, maxVolume);
        UpdateVolumes();
    }

    public void DecreaseMusicVolume()
    {
        musicVolume = Mathf.Clamp(musicVolume - 1, minVolume, maxVolume);
        UpdateVolumes();
    }

    public void IncreaseSFXVolume()
    {
        sfxVolume = Mathf.Clamp(sfxVolume + 1, minVolume, maxVolume);
        UpdateVolumes();
    }

    public void DecreaseSFXVolume()
    {
        sfxVolume = Mathf.Clamp(sfxVolume - 1, minVolume, maxVolume);
        UpdateVolumes();
    }

    private void UpdateVolumes()
    {
        mainAudioMixer.SetFloat("MasterVolume", Mathf.Log10((float)masterVolume / maxVolume) * 20);
        mainAudioMixer.SetFloat("BGM", Mathf.Log10((float)musicVolume / maxVolume) * 20);
        mainAudioMixer.SetFloat("SFX", Mathf.Log10((float)sfxVolume / maxVolume) * 20);
    }
}