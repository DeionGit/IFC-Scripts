using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CnnonFollower : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform FollowPos = null;
   
    void Update()
    {
        KeepFollowingPlayer();
    }

    void KeepFollowingPlayer()
    {

        Quaternion rotTarget = Quaternion.LookRotation(FollowPos.position- this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, speed * Time.deltaTime);

    }
}
