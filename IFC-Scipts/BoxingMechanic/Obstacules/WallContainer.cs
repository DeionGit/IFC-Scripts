using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallContainer : MonoBehaviour
{
    public Vector3 hitPosition;
    BrickBreacked[] bricks;
    [SerializeField] GameObject wallObs;
    [SerializeField] GameObject wallBrk;
    private void Awake()
    {
        bricks = GetComponentsInChildren<BrickBreacked>();
    }
    public void SetHitPosition(Vector3 hitPos)
    {
        hitPosition = hitPos;
    }
    public Vector3 GetHitPosition()
    {
        if (hitPosition != null)
        {
            return hitPosition;
        }
        else
        {
            return Vector3.zero;
        }
    }


    public void ExplodeWall()
    {
        wallObs.SetActive(false);
        wallBrk.SetActive(true);
    }
    
}
