using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class MovementPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float duration;
    public float multiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        } 
    }

    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerMovement stats = player.GetComponent<PlayerMovement>();
        stats.defaultSpeed *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.defaultSpeed /= multiplier;

        Destroy(gameObject);
    }
}
