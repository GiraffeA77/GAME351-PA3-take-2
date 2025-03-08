using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject debrisPrefab;
    public float bulletLifetime = 5f;
    public float damage = 10f;

    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dynamite"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Instantiate(debrisPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bandit"))
        {
            Animator banditAnimator = collision.gameObject.GetComponent<Animator>();
            if (banditAnimator != null)
            {
                banditAnimator.SetTrigger("Die");
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}


