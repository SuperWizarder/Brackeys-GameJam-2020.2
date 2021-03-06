﻿using TMPro;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    float health;
    public float startHealth;
    public float healRate;
    public float rewindRate;
    public float upgradeHealth;



    public TextMeshProUGUI healthText;

    public GameObject nextLevel;
    public GameObject lastLevel;

	private void Start()
	{
        health = startHealth;
	}

	private void Update()
    {
        if (RewindGun.isRewinding && health >= startHealth)
		{
            health -= Time.deltaTime * rewindRate;
        }
        else
		{
            health += Time.deltaTime * healRate;
		}

        healthText.text = (Mathf.RoundToInt(health)).ToString();

        if (health >= upgradeHealth && nextLevel != null)
        {
            LevelUp();
            Debug.Log("LevelUp");
        }
        /*else if(health >= upgradeHealth && nextLevel == null)
        {
            Die();
        }*/

        if (health <= startHealth && lastLevel != null)
		{
            LevelDown();
            Debug.Log("LevelDown");
		}
        /*else if (health <= startHealth && lastLevel == null)
		{
            Die();
            Debug.Log("LevelDown");
		}*/
    }

    void LevelUp()
    {
        Destroy(gameObject);
        Instantiate(nextLevel, transform.position, transform.rotation);
    }

    void LevelDown()
	{
        Destroy(gameObject);
        Instantiate(lastLevel, transform.position, transform.rotation);
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
