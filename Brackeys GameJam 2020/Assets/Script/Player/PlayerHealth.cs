using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health<= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0;
    }
}
