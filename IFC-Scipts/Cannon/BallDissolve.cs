using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallDissolve : MonoBehaviour
{
    GameObject parent;
    public MeshRenderer render;

    Outline outliner;

    public float undissolveValue;
    public float dissolveValue;
    public float timeToFade;
    private void Awake()
    {
        outliner = GetComponent<Outline>();
        render = GetComponent<MeshRenderer>();
        parent = transform.parent.gameObject;
    }
    
    public void Dissolve()
    {
        render.material.DOFloat(dissolveValue, "_DissolveAmmount", timeToFade).OnComplete(() =>
        {
            Destroy(parent);
        });
        DissolveOutline();
    }
    void DissolveOutline()
    {
        DOTween.To(SetOutline, 2, 0, 0.4f);
    }
    
    void SetOutline(float outlineWidth)
    {
        outliner.OutlineWidth = outlineWidth;
    }
}
