using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int currentHP;

    
    [SerializeField] eyelidAnimations UIEyesScript;
    void Start()
    {
        UIEyesScript = FindObjectOfType<eyelidAnimations>();
        ResetHp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") TakeDamage(1); 
        if (collision.gameObject.GetComponent<WallObstacule>())
        {
             TakeDamage(1);
        }
        if(collision.gameObject.layer == 7)
        {
            TakeDamage(1);
        }

        if(collision.gameObject.GetComponent<BoxingObstacules>())
        {
            if (collision.gameObject.GetComponent<ButtonDissolve>()) return;
            if(!collision.gameObject.GetComponent<BoxingObstacules>().eliminated) TakeDamage(1);
        }
        if (collision.gameObject.GetComponent<BallCannon>())
        {
            if (!collision.gameObject.GetComponent<BallCannon>().eliminated) TakeDamage(1);
        }

        Debug.Log(collision.gameObject.tag);
    }
    public void TakeDamage(int damage)
    {
        if (currentHP <= 0) return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            UIEyesScript.CallEyelidAnimation();
        }
        else
        {
            //dañado (MODO FACIL)
        }
    }

    public void ResetHp()
    {
        currentHP = maxHP;
    }
}
