using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLight : MonoBehaviour
{
    public Color32 lightColor;

    public bool lightChanging = false;

    public static LevelLight instance;
    private void Awake()
    {
        #region Singleton
        if (instance == null) instance = this;
        else Destroy(this);
        #endregion


    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
