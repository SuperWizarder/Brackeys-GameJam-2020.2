using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    public float damage;

    private GameObject player;
    private Vector3 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
