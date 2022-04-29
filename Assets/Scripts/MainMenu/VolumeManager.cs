using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;

    string[] master = { "MasterVolume", "MasterVol" };
    string[] music = { "MusicVolume", "MusicVol" };
    string[] sfx = { "SfxVolume", "SfxVol" };

    void Start()
    {
        masterVolume.value = PlayerPrefs.GetFloat(master[0], 0.75f);
        musicVolume.value = PlayerPrefs.GetFloat(music[0], 0.75f);
        sfxVolume.value = PlayerPrefs.GetFloat(sfx[0], 0.75f);
    }
    public void SetMasterVolume()
    {
        float sliderValue = masterVolume.value;
        mixer.SetFloat(master[1], Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(master[0], sliderValue);
    }

    public void SetMusicVolume()
    {
        float sliderValue = musicVolume.value;
        mixer.SetFloat(music[1], Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(music[0], sliderValue);
    }

    public void SetSfxVolume()
    {
        float sliderValue = sfxVolume.value;
        mixer.SetFloat(sfx[1], Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(sfx[0], sliderValue);
    }
}
