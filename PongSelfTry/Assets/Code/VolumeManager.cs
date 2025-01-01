using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour

{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
        SaveVolume();
    }
    public void SetSFXVolume()
    {
        float SFXVolume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
        SaveVolume();
    }

    public void SaveVolume()
    {
        float musicVolume = musicSlider.value;
        float SFXVolume = SFXSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
}