using TMPro;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    float health;
    public float startHealth;
    public float healRate;
    public float upgradeHealth;

    public TextMeshProUGUI healthText;

    public GameObject nextLevel;

	private void Start()
	{
        health = startHealth;
	}

	private void Update()
    {
        health += Time.deltaTime * healRate;

        healthText.text = (Mathf.RoundToInt(health)).ToString();

        if (health >= upgradeHealth)
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
