using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    PlayerHP playerHP;
    
    private void Awake()
    {
        playerHP = FindObjectOfType<PlayerHP>();
        gameObject.tag = "HeadPlayer";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxingObstacules>())
        {
            if (collision.gameObject.GetComponent<ButtonDissolve>()) return;
            if (!collision.gameObject.GetComponent<BoxingObstacules>().eliminated) playerHP.TakeDamage(1);
        }
        
        if (collision.gameObject.layer == 7)
        {
            playerHP.TakeDamage(1);
        }
        if (collision.gameObject.GetComponent<WallObstacule>())
        {
            playerHP.TakeDamage(1);
        }
    }
    
}
