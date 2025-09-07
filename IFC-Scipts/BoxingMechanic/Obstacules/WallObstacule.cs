using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacule : MonoBehaviour
{
    [SerializeField] GameObject wallBreacked;

    public float minForceToHit;
    public bool eliminated = false;

    public WallContainer wallCont;

    private void Awake()
    {
        wallCont = GetComponentInParent<WallContainer>();
    }
    private void OnEnable()
    {
        eliminated = false;
    }
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        DetectPunch(collision);
    }
    void Update()
    {
        
    }
    void DetectPunch(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxingGloves>() != null && !eliminated)
        {
            BoxingGloves boxingScript = collision.gameObject.GetComponent<BoxingGloves>();
            eliminated = true;
            if (boxingScript.GetMagnitude() >= minForceToHit && boxingScript.canHit)
            {
                wallCont.ExplodeWall();
                boxingScript.CallHitCoolDown();
                //Set particules pos
                Vector3 partSpawnPos = collision.GetContact(0).point;
                GameObject hitPart = ObjectPooling.instance.SpawnFromPool("NormalHitEffect", partSpawnPos, Quaternion.identity, null);
                wallCont.SetHitPosition(partSpawnPos); //Le pasa el valor Vector 3 a Wall container para poder hacer la explosion(Realista) en varios pedazos
                //Play hit particules
                hitPart.GetComponent<ParticleSystem>().Play();
                hitPart.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                //Add physics forces to the hitted obstacule
                
                //Calling Combo system
                ComboDetection.instance.CallHoloCombo();
                //Calling the Haptics from controller
                boxingScript.CallThisGloveHaptics();
                //Dissolving Obstcule
              
                
            }
        }
    }
}
