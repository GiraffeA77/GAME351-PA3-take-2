using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource; // Reference to AudioSource component
    public string deathTrigger = "Die";
    public float destroyAfterAnimation = 2f; // Time before the GameObject is destroyed
    public AudioClip deathAudioClip; // Audio clip for death sound

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayDeathSound(); // Play death sound on collision
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

    private void PlayDeathSound()
    {
        if (audioSource != null && deathAudioClip != null)
        {
            audioSource.PlayOneShot(deathAudioClip); // Play the death sound clip
        }
    }

    private System.Collections.IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(destroyAfterAnimation);
        Destroy(gameObject);
    }
}


