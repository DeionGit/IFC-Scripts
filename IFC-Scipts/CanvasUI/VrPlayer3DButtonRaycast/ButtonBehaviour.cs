using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonBehaviour : MonoBehaviour
{

    bool canRotate = false;
    public float speedRot;
    Quaternion startPos;
    void Start()
    {
        startPos = transform.rotation; 
    }

   
    void Update()
    {
        if (canRotate) Rotating(speedRot);
    }

    public void StartRotating()
    {
        canRotate = true;
    }
    void Rotating(float speed)
    {
        transform.Rotate(new Vector3(0,1,0) * speed * Time.deltaTime);
    }
    public void StopRotating()
    {
        canRotate = false;
        transform.DORotateQuaternion(startPos, 0.7f).SetEase(Ease.OutQuad);
    }
}
