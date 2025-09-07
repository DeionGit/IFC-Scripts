using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CannonManager : MonoBehaviour
{
    public float cannonTimeAppear;
    public float cannonTimeShoot;

    [Header("Cannon positions")]
    [SerializeField] float xRightPos, xLeftPos;


    ITargetDetection ICannonShoot;

    CannonDissolver cannonDissolver;
    
    public bool cannonON = false;
    private void Awake()
    {
        ICannonShoot = FindObjectOfType<CannonShoot>().GetComponent<ITargetDetection>();

        cannonDissolver = GetComponentInChildren<CannonDissolver>();
    }
    public void StartCannonGame()
    {
        cannonON = true;
        StartCoroutine(TryCannonAppear());

        Debug.Log("Empieza");
        
    }
    IEnumerator TryShootCannon()
    {
        int tryEnable = Random.Range(0, 6);
        Debug.Log("Intenta Disparar"); 
        yield return new WaitForSeconds(cannonTimeShoot);
        if (tryEnable < 2) EnableShoot();
        else MakeCannonDissappear();
    }
    IEnumerator TryCannonAppear()
    {
        Debug.Log("IntentaAparecer");
        if (!cannonON) yield break;
        int appear = Random.Range(0, 6);
           yield return new WaitForSeconds(cannonTimeAppear);
        if (appear < 2) MakeCannonAppear();
        else StartCoroutine(TryCannonAppear());
    }
    void MakeCannonAppear() 
    {
        Debug.Log("Hace aparecer el cañon");
        cannonDissolver.UndissolveCannon();
        cannonDissolver.undissolveSeq.OnComplete(() =>
        {
            Debug.Log("Funciona aparecer??");
            StartCoroutine(TryShootCannon());
        });
    }
    void MakeCannonDissappear()
    {
        Debug.Log("Hace desaparecer el cañon");
        cannonDissolver.DissolveCannon();
        cannonDissolver.dissolveSeq.OnComplete(() =>
        {
            CannonRepos();
            StartCoroutine(TryCannonAppear());
        });
    }
    public void EnableShoot()
    {
        ICannonShoot.TargetDetected();
        Invoke("MakeCannonDissappear", 1f);
    }
    
    public void ResetCannon()
    {
        if (cannonON)
        {
            StopCoroutine(TryCannonAppear());
            cannonDissolver.DissolveCannon();
            cannonDissolver.dissolveSeq.OnComplete(() =>
            {
                cannonON = false;
            });
        }
        
    }

    public void CannonRepos()
    {
        int randomPos = Random.Range(0, 5);
        if (randomPos < 2)
        {
            transform.position = new Vector3(xLeftPos, transform.position.y, transform.position.z);
        }
        else
        {
           transform.position = new Vector3(xRightPos, transform.position.y, transform.position.z);
        }
    }
}
