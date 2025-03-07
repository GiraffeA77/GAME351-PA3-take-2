using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private Animator animator;
    public string deathTrigger = "Die";
    public float destroyAfterAnimation = 2f; // Time before the GameObject is destroyed

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayDeathAnimation();
            Destroy(collision.gameObject); // Destroy the bullet on impact
        }
    }

    public void PlayDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(deathTrigger);
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private System.Collections.IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(destroyAfterAnimation);
        Destroy(gameObject);
    }
}

