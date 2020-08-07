using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Guns : MonoBehaviour
{
    public float damage, range, spread;
    public float amountOfBullets;

    public float shakeMagnitude, shakeRoughness,fadeInTime,fadeOutTime;

    public ParticleSystem muzzleFlash;
    public GameObject impactFX;

    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        muzzleFlash.Play();

        CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, fadeInTime, fadeOutTime);

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range))
        {
            AI_Health health = hit.transform.GetComponent<AI_Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.25f);
        }
    }
}
