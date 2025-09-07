using Blobcreate.Universal;
using UnityEngine;

public class BallCannon : ProjectileBehaviour
{
	
    public bool eliminated = false;

    BallDissolve ballDissolve;
    private void Start()
    {
        ballDissolve = GetComponentInChildren<BallDissolve>();
    }
    protected override void OnLaunch()
    {
	}


     protected override void OnCollisionEnter(Collision collision)
     {
        if (!eliminated)
        {
            if (collision.gameObject.GetComponent<PlayerHP>() || collision.gameObject.GetComponent<HeadCollider>())
            {
                //collision.gameObject.GetComponent<PlayerHP>().TakeDamage(1);

                ballDissolve.Dissolve();
            }
            else
            {
                ballDissolve.Dissolve();
            }
            eliminated = true;
            ballDissolve.Dissolve();
        }
     }

}


