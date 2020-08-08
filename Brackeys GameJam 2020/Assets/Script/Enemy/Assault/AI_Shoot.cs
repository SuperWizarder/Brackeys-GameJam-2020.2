using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shoot : MonoBehaviour
{
    public Transform firePoint;
    private Transform player;

    public float bulletSpeed;

    public float range, damage;

    public float fireRange;

    public GameObject bullet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < fireRange)
            {
                Shoot();
            }        
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

}
