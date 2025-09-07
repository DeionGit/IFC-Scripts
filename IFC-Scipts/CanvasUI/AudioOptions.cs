using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using MText;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] Modular3DText masterText;
    [SerializeField] Modular3DText musicText;
    [SerializeField] Modular3DText sfxText;

    [SerializeField] AudioMixer audioMix;

    public float MasterVol = 80;//<----Almacenan los valores representados en las opciones, pero no los reales del volumen
    public float MusicVol = 80;
    public float SFXVol = 80;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        LoadAudioPref("MasterVolume");
        LoadAudioPref("SFXVolume");
        LoadAudioPref("MusicVolume");
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonMaster(-10);
        if (Input.GetKeyDown(KeyCode.M)) ButtonMaster(10);

        if (Input.GetKeyDown(KeyCode.Tab)) ButtonSFX(-10);
        if (Input.GetKeyDown(KeyCode.AltGr)) ButtonSFX(10);
    }

    void ButtonChangeVolume(string audioParameter, float volumeAdd)
    {
        float newVolume;
        audioMix.GetFloat(audioParameter, out newVolume);
        if (newVolume < 20 && newVolume > -80)
        {
            newVolume += volumeAdd;
            audioMix.SetFloat(audioParameter, newVolume);

            UpdateVolumeText(audioParameter,volumeAdd);
            
        }
        else if(newVolume == 20 && volumeAdd == -10)
        {
            newVolume += volumeAdd;
            audioMix.SetFloat(audioParameter, newVolume);

            UpdateVolumeText(audioParameter, volumeAdd);
            
        }
        else if(newVolume == -80 && volumeAdd == 10)
        {
            newVolume += volumeAdd;
            audioMix.SetFloat(audioParameter, newVolume);

            UpdateVolumeText(audioParameter, volumeAdd);
            
        }
        SetAudioPref(audioParameter, newVolume);
    }
    public void ButtonMaster(float volumeAdd)
    {
        ButtonChangeVolume("MasterVolume", volumeAdd);
    }
    public void ButtonSFX(float volumeAdd)
    {
        ButtonChangeVolume("SFXVolume", volumeAdd);
    }
    public void ButtonMusic(float volumeAdd)
    {
        ButtonChangeVolume("MusicVolume", volumeAdd);
    }
    void UpdateVolumeText(string audioParameter, float volumeChange)
    {
        switch (audioParameter)
        {
            case "MasterVolume":
               
                MasterVol += volumeChange;
                masterText.UpdateText(MasterVol);

                SetAudioPref("MasterVolumeUI", MasterVol);
                break;

            case "SFXVolume":
                
                SFXVol += volumeChange;
                sfxText.UpdateText(SFXVol);

                SetAudioPref("SFXVolumeUI", SFXVol);
                break;

            case "MusicVolume":
                
                MusicVol += volumeChange;
                musicText.UpdateText(MusicVol);

                SetAudioPref("MusicVolumeUI", MusicVol);
                break;
        }
        
    }
    void SetAudioPref(string audioParameter, float volume)
    {
        PlayerPrefs.SetFloat(audioParameter, volume);
    }
    void LoadAudioPref(string audioParameter)
    {
        switch (audioParameter)
        {
            case "MasterVolume":
                MasterVol = PlayerPrefs.GetFloat(audioParameter + "UI", 80);
                          masterText.UpdateText(MasterVol);
                audioMix.SetFloat(audioParameter, PlayerPrefs.GetFloat(audioParameter));
                Debug.Log("MasterVolume ha cargado el volumen " + PlayerPrefs.GetFloat(audioParameter));
                break;

            case "SFXVolume":
                SFXVol = PlayerPrefs.GetFloat(audioParameter + "UI", 80);
                       sfxText.UpdateText(SFXVol);
                audioMix.SetFloat(audioParameter, PlayerPrefs.GetFloat(audioParameter));
                Debug.Log("SFXVolume ha cargado el volumen " + PlayerPrefs.GetFloat(audioParameter));
                break;

            case "MusicVolume":
                MusicVol = PlayerPrefs.GetFloat(audioParameter + "UI", 80);
                         musicText.UpdateText(MusicVol);

                audioMix.SetFloat(audioParameter, PlayerPrefs.GetFloat(audioParameter));
                Debug.Log("MusicVolume ha cargado el volumen " + PlayerPrefs.GetFloat(audioParameter));
                break;
        }
    }
    
}
