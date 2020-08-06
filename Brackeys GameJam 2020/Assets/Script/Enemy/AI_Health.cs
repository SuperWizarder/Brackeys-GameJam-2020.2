using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    public float health;
    public int healthPerSec;

    public float upgradeHealth;

    public GameObject nextLevel;

    // Update is called once per frame
    void Update()
    {
        health += Time.deltaTime;

        if(health >= upgradeHealth)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Destroy(gameObject);
        Instantiate(nextLevel, transform.position, transform.rotation);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
