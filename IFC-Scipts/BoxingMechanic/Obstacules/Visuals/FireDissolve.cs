using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireDissolve : MonoBehaviour
{
    [SerializeField] float startY, targetY;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        transform.DOLocalMoveY(targetY, 1.8f).SetEase(Ease.OutCubic);
    }
    private void OnDisable()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, startY, transform.localPosition.z);
    }

    void Update()
    {
        
    }
}
