using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsController : MonoBehaviour
{
    public GameObject activePanel;

    static public PanelsController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
}
