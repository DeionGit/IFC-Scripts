using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlDifficulty : MonoBehaviour
{
    [SerializeField] float newSpeed;
    [SerializeField] float upSpeed = 0.5f;

    EnviromentMoving[] envirMovings;
    void Start()
    {
        envirMovings = FindObjectsOfType<EnviromentMoving>();
        newSpeed = envirMovings[0].maxSpeed;
    }
    public void ResetNewSpeed()
    {
        newSpeed = 5;
    }

   public void SetNewSpeedToMap()
   {
        newSpeed += upSpeed;
        foreach(EnviromentMoving envirMove in envirMovings)
        {
            envirMove.speed = newSpeed;
        }
   }
}
