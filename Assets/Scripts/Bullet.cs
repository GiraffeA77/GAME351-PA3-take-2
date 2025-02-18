using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject debrisPrefab;
    public float bulletLifetime = 5f;

    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
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
            Destroy(collision.gameObject, 1f);
        }

        Destroy(gameObject);
    }
}
