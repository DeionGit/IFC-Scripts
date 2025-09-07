using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blobcreate.Universal;
using Blobcreate.ProjectileToolkit;

public class CannonShoot : MonoBehaviour, ITargetDetection
{
    [Header("CannonShootingVariables")]
    [SerializeField] GameObject bulletPref;
    [SerializeField] ParticleSystem ShootingParticles;

    [SerializeField] Transform firePoint;
    [SerializeField] Transform target;
    public float launchAngle;
    public float launchSpeed;

    public bool CannonOn = false;
    
    void Start()
    {
        GetHeadPos();
    }
    void GetHeadPos()
    {
        target = FindObjectOfType<HeadCollider>().transform;
    }
    private void Update()
    {
        CannonShooting();
    }
    public void TargetDetected()
    {
        CannonOn = true;
        
    }
    public void TargetLosed()
    {
        CannonOn = false;
        
    }

    void CannonShooting()
    {
        var launchVelocity = default(Vector3);

        launchVelocity = Projectile.VelocityByAngle(firePoint.position, target.position, launchAngle);

        if (!CannonOn) return;
        if (launchVelocity != default)
        {
            var bullet = Instantiate(bulletPref, firePoint.position, bulletPref.transform.rotation);
            EnableShootingParticles();
            Debug.Log("Disparo");
            bullet.GetComponent<ProjectileBehaviour>().Launch(Vector3.one);
            bullet.GetComponent<Rigidbody>().AddForce(launchVelocity, ForceMode.VelocityChange);
        }
        TargetLosed();
    }

    void EnableShootingParticles()
    {
        ShootingParticles.Play();
    }

}

interface ITargetDetection
{
    void TargetDetected();
    void TargetLosed();
}