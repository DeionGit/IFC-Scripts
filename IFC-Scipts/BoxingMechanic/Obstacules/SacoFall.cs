using UnityEngine;

public class SacoFall : MonoBehaviour
{
    [SerializeField] string offTag;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == offTag)
        {
            KinematicOff();
        }
        
    }
    
    public void KinematicOff()
   {
        rb.isKinematic = false;
   }
}
