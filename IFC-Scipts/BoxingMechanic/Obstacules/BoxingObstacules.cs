using UnityEngine;

public class BoxingObstacules : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] Collider obstaculeCollider;
    public string boxingGlovesTag;
    public float forceExplosion;
    public float minForceToHit;

    public bool eliminated;
    [SerializeField] DissolveObstacule dissolveObstacule;

    private void OnEnable()
    {
        eliminated = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dissolveObstacule = GetComponent<DissolveObstacule>();
        eliminated = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            DisableAndDissolveObstacule();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!eliminated)
        {
            DetectPunch(collision);
        }
    }
    void DetectPunch(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxingGloves>() != null && !dissolveObstacule.isDissolving && !eliminated)
        {
            BoxingGloves boxingScript = collision.gameObject.GetComponent<BoxingGloves>();
            
            if (boxingScript.GetMagnitude() >= minForceToHit && boxingScript.canHit )
            {
                eliminated = true;
                boxingScript.CallHitCoolDown();
                //Set particules pos
                Vector3 partSpawnPos = collision.GetContact(0).point; 
                GameObject hitPart = ObjectPooling.instance.SpawnFromPool("NormalHitEffect", partSpawnPos, Quaternion.identity, null);
                //Play hit particules
                hitPart.GetComponent<ParticleSystem>().Play();
                hitPart.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
               //Add physics forces to the hitted obstacule
                rb.AddForce(collision.gameObject.GetComponent<BoxingGloves>().GetDirection() * forceExplosion, ForceMode.Impulse);
                //Calling Combo system
                ComboDetection.instance.CallHoloCombo();
                //Calling the Haptics from controller
                boxingScript.CallThisGloveHaptics();
                //Dissolving Obstcule
                DisableAndDissolveObstacule();
            }
        }
    }
   public void DisableAndDissolveObstacule()
   {
        dissolveObstacule.DissolveIt();
   }

}
