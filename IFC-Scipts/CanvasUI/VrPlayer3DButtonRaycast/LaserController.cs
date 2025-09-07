using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    LineRenderer line;

    bool lineOn = false;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }


    public void LineEnable()
    {
        if (line.enabled) return;
        else 
        {
            line.enabled = true;
            lineOn = true;
        }
        
    }
    public void LineDisable()
    {
        if (!line.enabled) return;
        else
        {
            line.enabled = false;
            lineOn = false;
        }
    }

    public void SetLaserDistance(RaycastHit hit)
    {
        if (lineOn)
        {
            line.SetPosition(1,transform.InverseTransformPoint(hit.point));
        }
    }
    
}
