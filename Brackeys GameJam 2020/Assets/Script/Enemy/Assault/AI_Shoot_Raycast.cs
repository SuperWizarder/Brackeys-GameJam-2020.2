using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shoot_Raycast : MonoBehaviour
{
    public Transform firePoint;

    public float damage;
    public float retreatDistance;

    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleFlash2;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= retreatDistance)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        muzzleFlash2.Play();

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit))
        {


            AI_Health health = hit.transform.GetComponent<AI_Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

}
