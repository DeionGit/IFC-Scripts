using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbellObstacule : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        ForwardMovement();
    }

    void ForwardMovement()
    {
        rb.velocity = Vector3.forward * moveSpeed;
    }
}

//Deberia spawnear en derecha (x = 0.9
//                    izquierda (x = 2.09
