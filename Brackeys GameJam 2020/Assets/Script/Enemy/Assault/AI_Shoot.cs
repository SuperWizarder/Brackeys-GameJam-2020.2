using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shoot : MonoBehaviour
{
    public float rangeToShoot;

    public Transform firePoints;

    public float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectiles;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectiles, firePoints.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
