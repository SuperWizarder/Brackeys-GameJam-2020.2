using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Guns : MonoBehaviour
{
    public float damage, range, spread;

    public float fireRate;
    float nextTimeToFire = 0f;

    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;

    bool isReloading = false;

    public float shakeMagnitude, shakeRoughness,fadeInTime,fadeOutTime;

    public ParticleSystem muzzleFlash;
    public GameObject impactFX;

    public float recoilForce;
    public Rigidbody playerRB;

    public Animator animator;
    public Camera fpsCam;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }


    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            animator.Play("Shooting");
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    
    void Shoot()
    {
        muzzleFlash.Play();

        FindObjectOfType<AudioManager>().Play("GunShot");

        currentAmmo--;
        CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, fadeInTime, fadeOutTime);

        Vector3 direction = fpsCam.transform.forward;

        playerRB.AddForce(-direction.normalized * recoilForce, ForceMode.Impulse);

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
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

    IEnumerator Reload()
    {
        isReloading = true;

        animator.SetBool("Reloading", true);

        FindObjectOfType<AudioManager>().Play("Reload");

        yield return new WaitForSeconds(reloadTime -.25f);
        yield return new WaitForSeconds(.25f);

        animator.SetBool("Reloading", false);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
