using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public GameObject[] activeVolumeIndicators;  // 활성화된 모양 오브젝트 배열
    public GameObject[] inactiveVolumeIndicators;  // 비활성화된 모양 오브젝트 배열

    private int masterVolume = 6;
    private const int maxVolume = 6;
    private const int minVolume = 1;

    void Start()
    {
        UpdateVolumes();
        InitializeVolumeIndicators(activeVolumeIndicators, masterVolume, true);
        InitializeVolumeIndicators(inactiveVolumeIndicators, masterVolume, false);
    }

    public void IncreaseMasterVolume()
    {
        Debug.Log("IncreaseMasterVolume clicked");
        if (masterVolume < maxVolume)
        {
            masterVolume++;
            UpdateVolumeIndicators(activeVolumeIndicators, inactiveVolumeIndicators, masterVolume);
            UpdateVolumes();
            Debug.Log("Master Volume Increased: " + masterVolume);
        }
    }

    public void DecreaseMasterVolume()
    {
        Debug.Log("DecreaseMasterVolume clicked");
        if (masterVolume > minVolume)
        {
            masterVolume--;
            UpdateVolumeIndicators(activeVolumeIndicators, inactiveVolumeIndicators, masterVolume);
            UpdateVolumes();
            Debug.Log("Master Volume Decreased: " + masterVolume);
        }
    }

    private void UpdateVolumes()
    {
        mainAudioMixer.SetFloat("MasterVolume", Mathf.Log10((float)masterVolume / maxVolume) * 20);
        Debug.Log("Volumes Updated: Master: " + masterVolume);
    }

    private void InitializeVolumeIndicators(GameObject[] indicators, int volumeLevel, bool isActive)
    {
        for (int i = 0; i < indicators.Length; i++)
        {
            Animator animator = indicators[i].GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play("Idle");
                if (i < volumeLevel)
                {
                    animator.SetTrigger(isActive ? "ActivateTrigger" : "DeactivateTrigger");
                    Debug.Log("Indicator " + i + " Initialized as " + (isActive ? "Activated" : "Deactivated"));
                }
                else
                {
                    animator.SetTrigger(isActive ? "DeactivateTrigger" : "ActivateTrigger");
                    Debug.Log("Indicator " + i + " Initialized as " + (isActive ? "Deactivated" : "Activated"));
                }
            }
        }
    }

    private void UpdateVolumeIndicators(GameObject[] activeIndicators, GameObject[] inactiveIndicators, int volumeLevel)
    {
        for (int i = 0; i < activeIndicators.Length; i++)
        {
            Animator activeAnimator = activeIndicators[i].GetComponent<Animator>();
            Animator inactiveAnimator = inactiveIndicators[i].GetComponent<Animator>();
            if (activeAnimator != null && inactiveAnimator != null)
            {
                if (i < volumeLevel)
                {
                    activeAnimator.SetTrigger("ActivateTrigger");
                    inactiveAnimator.SetTrigger("DeactivateTrigger");
                    Debug.Log("Indicator " + i + " Activated");
                }
                else
                {
                    activeAnimator.SetTrigger("DeactivateTrigger");
                    inactiveAnimator.SetTrigger("ActivateTrigger");
                    Debug.Log("Indicator " + i + " Deactivated");
                }
            }
        }
    }
}
