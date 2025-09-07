using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDecorationReset : MonoBehaviour
{
    EnviromentDecoration[] allDecorations;
    public static AllDecorationReset instance;
    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion

        allDecorations = FindObjectsOfType<EnviromentDecoration>();
    }

    public void ResetRunDecoration()//Desactiva toda la decoraci�n
    {
        foreach(EnviromentDecoration enviDeco in allDecorations)
        {
           if(enviDeco.needResetList) enviDeco.ListReset();
        }
    }
}
