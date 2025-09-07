using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCollisionSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] randomClips;
   
    public AudioClip GetRandomAudio()
    {
        int lenghtToint = randomClips.Length ;
        int num = Random.Range(0, lenghtToint);
        return randomClips[num];
    }
   
}
