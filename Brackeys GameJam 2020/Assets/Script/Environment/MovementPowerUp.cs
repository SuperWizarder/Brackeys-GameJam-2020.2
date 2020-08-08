using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class MovementPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float duration;
    public float multiplier;
    public float sprintMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        } 
    }

    IEnumerator PickUp(Collider player)
    {
        GameObject pickupGO = Instantiate(pickupEffect, transform.position, transform.rotation);

        CameraShaker.Instance.ShakeOnce(35f, 2f, 1f, 1f);

        PlayerMovement stats = player.GetComponent<PlayerMovement>();
        stats.defaultSpeed *= multiplier;
        stats.sprintSpeed *= sprintMultiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Destroy(pickupGO, 2f);

        yield return new WaitForSeconds(duration);

        stats.defaultSpeed /= multiplier;
        stats.sprintSpeed /= sprintMultiplier;

        Destroy(gameObject); 
    }
}
