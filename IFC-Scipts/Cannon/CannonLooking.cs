using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLooking : MonoBehaviour, ITargetDetection
{
    public float rotSpeed = 20f;

    [SerializeField] Transform playerTarget;
    bool lookingTarget = false;
    private void Start()
    {
        GetHeadPos();
    }
    void GetHeadPos()
    {
        playerTarget = FindObjectOfType<HeadCollider>().transform;
    }
    void FixedUpdate()
    {
         LookingToTarget(); // Looking constantly to player head
    }

    void LookingToTarget() // Aplying Looking To Player
    {
        if (!lookingTarget) return;
        else transform.LookAt(new Vector3(playerTarget.position.x, transform.position.y, playerTarget.position.z));
    }
    public void TargetDetected()
    {
        lookingTarget = true;
    }
    public void TargetLosed()
    {
        lookingTarget = false;
    }
}

