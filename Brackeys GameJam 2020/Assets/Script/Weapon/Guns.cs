using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    //Stats
    public int damage;
    public float fireRate, spread, range, reloadTime, timeBetweenShots;

    public int magazineSize, bulletPerTap;
    int bulletLeft, bulletsShots;

    public bool allowButtonHold;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera playerCam;
    public Transform attackPoint;

    public RaycastHit hit;

    //Graphic
    public GameObject muzzleFlash, bulletHoleGraphic, impactFX;

    public CameraShake camShake;
    public float camShakeMagnitude, camShakeDuration;


    private void Awake()
    {
        bulletLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        GunInput();
    }
    private void GunInput()
    {
        if(allowButtonHold)
            shooting = Input.GetButton("Fire1");
        else
            shooting = Input.GetButtonDown("Fire1");

        if (Input.GetKeyDown(KeyCode.R) || bulletLeft < magazineSize && !reloading)
            Reload();

        //Shoot
        if(readyToShoot && shooting && !reloading && bulletLeft > 0)
        {
            bulletsShots = bulletPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread,spread);

        Vector3 direction = playerCam.transform.forward + new Vector3(x, y, 0);

        //Raycast
        if(Physics.Raycast(playerCam.transform.position, direction, out hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
                hit.collider.GetComponent<AI_Health>().TakeDamage(damage);
        }

        //ShakeCamera
        camShake.Shake(camShakeDuration, camShakeMagnitude);

        bulletLeft--;
        bulletsShots--;

        //Graphics
        Instantiate(impactFX, hit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        Invoke("ResetShot", fireRate);

        if(bulletsShots > 0 && bulletLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;

        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletLeft = magazineSize;
        reloading = false;
    }
}
