using UnityEngine;
using EZCameraShake;

public class Gun : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public RaycastHit rayHit;

    public Animator anim;

    //Graphics
    public ParticleSystem muzzleFlash;
    public GameObject impactFX;

    public float magnitude, roughness, fadeInTime, fadeOutTime;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) || bulletsLeft <= 0 && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);

            AI_Health ai_Health = rayHit.collider.GetComponent<AI_Health>();

            if(ai_Health != null)
            {
                ai_Health.TakeDamage(damage);
            }
        }

        //ShakeCamera
        CameraShaker.Instance.ShakeOnce(magnitude,roughness, fadeInTime,fadeOutTime);

        //Graphics
        muzzleFlash.Play();

        GameObject impactGO = Instantiate(impactFX, rayHit.point, Quaternion.Euler(0, 180, 0));
        Destroy(impactGO, 0.25f);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
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

        anim.SetBool("Reloading", true);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;

        anim.SetBool("Reloading", false);
    }
}