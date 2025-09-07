using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrickBreacked : MonoBehaviour
{
    Vector3 startPos;
    Rigidbody rb;
    GameObject parentWall;
    MeshRenderer brickRender;
    public float dissolveValue;
    public float timeToFade;
    public WallContainer wallCont;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        brickRender = GetComponent<MeshRenderer>();
        wallCont = GetComponentInParent<WallContainer>();
        parentWall = transform.parent.gameObject;
    }
    private void OnEnable()
    {
        startPos = transform.localPosition;
        DoExplosion();
    }
   
    void DoExplosion()
    {
        rb.AddExplosionForce(1000, wallCont.GetHitPosition(), 4);
        Dissolve();
    }
    void Dissolve()
    {
        brickRender.material.DOFloat(dissolveValue, "_Destruction", timeToFade).OnComplete(() =>
        {
            if (parentWall.activeSelf)
            {
                parentWall.SetActive(false);
            }
            
        });
    }
    private void OnDisable()
    {
        transform.localPosition = startPos;
        //brickRender.material.SetFloat("_Destruction", 1.5f);
    }
}
