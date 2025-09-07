using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSacoRot : MonoBehaviour
{
    [SerializeField] GameObject sacoBag;
    private void Awake()
    {
        sacoBag = transform.GetChild(0).gameObject;
    }
    private void OnEnable()
    {
        sacoBag.transform.localRotation = new Quaternion(160, 0, 0, 0);
        sacoBag.GetComponent<Rigidbody>().isKinematic = true;
    }
}
