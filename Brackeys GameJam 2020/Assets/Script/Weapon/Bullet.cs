using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Bullet : MonoBehaviour
{
    #region Variables
    public float speed;

    private Rigidbody rb;

    private Transform player;
    private Vector2 target;

    public GameObject explosion;
    public float cookingTime;

    public float damage;

    public float explosionForce = 10f;
    public float radius = 500f;
    #endregion

    #region Unity Methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = transform.forward;

        rb.AddForce(target * speed, ForceMode.Force);
    }



    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
    #endregion

    #region Methods
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        CameraShaker.Instance.ShakeOnce(0.2f, 0.3f, .1f, 2f);

        foreach (Collider near in colliders)
        {
            Rigidbody rb = near.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
            }

            PlayerHealth dest = near.GetComponent<PlayerHealth>();
            if (dest != null)
            {
                dest.TakeDamage(damage);
            }
        }
        GameObject explodeGO = Instantiate(explosion, transform.position, transform.rotation);

        Destroy(explodeGO, 4f);

        Destroy(gameObject);
    }
    #endregion
}
