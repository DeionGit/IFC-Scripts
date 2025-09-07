using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightUse : MonoBehaviour
{
    Light thisLight;
    private void Awake()
    {
        thisLight = GetComponent<Light>();
    }
    void Update()
    {
        GetLightColor();
    }

    void GetLightColor()
    {
        if (!thisLight.enabled && LevelLight.instance.lightChanging)
        {
            return;
        }
        else thisLight.color = LevelLight.instance.lightColor;
    }
}
