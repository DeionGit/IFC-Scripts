using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    AudioSource menuAudioSource;

    [SerializeField] AudioClip clickSfx;
    private void Awake()
    {
        menuAudioSource = GetComponent<AudioSource>();
    }
    
    public void ClickSound()
    {
        menuAudioSource.PlayOneShot(clickSfx);
    }


}
