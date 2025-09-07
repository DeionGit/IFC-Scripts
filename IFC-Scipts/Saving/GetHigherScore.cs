using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetHigherScore : MonoBehaviour
{
    public int higherComboInRun = 0;
    
    public static GetHigherScore instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void ResetHigherComboInRun()
    {
        higherComboInRun = 0;
    }
}
