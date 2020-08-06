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
        health += healthPerSec * Time.deltaTime;

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
}
