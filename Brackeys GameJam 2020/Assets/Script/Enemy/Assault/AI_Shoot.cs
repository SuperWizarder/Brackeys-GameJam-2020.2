using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shoot : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform player;

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
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            PlayerHealth health = hit.collider.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

}
