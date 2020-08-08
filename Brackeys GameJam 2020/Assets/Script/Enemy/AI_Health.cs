using TMPro;
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

        if (health >= upgradeHealth)
        {
            LevelUp();
            Debug.Log("LevelUp");
        }

        if (health < startHealth)
		{
            LevelDown();
            Debug.Log("LevelDown");
		}
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
