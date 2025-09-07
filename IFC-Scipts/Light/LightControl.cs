using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightControl : MonoBehaviour
{
    [SerializeField] Light[] lights;

    [SerializeField] float turnOnLightTime;
    void Start()
    {
        DeactivateLights();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHP>())
        {
            ActivateLights();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHP>())
        {
            DeactivateLights();
        }
        
    }
    void ActivateLights()
    {
        foreach (Light light in lights)
        {
            light.enabled = true;
            light.DOIntensity(30f, turnOnLightTime).SetEase(Ease.Flash);
        }
    }
    void DeactivateLights()
    {
        foreach(Light light in lights)
        {
            light.DOIntensity(30f, turnOnLightTime).SetEase(Ease.Flash).OnComplete(() =>
            {
                light.enabled = false;
            });
        }
    }
}
