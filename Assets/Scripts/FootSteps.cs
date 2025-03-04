using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip footstepSound; // Assign footstep sound in Inspector
    private AudioSource audioSource; // Reference to AudioSource
    private Animator animController; // Animator reference

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animController = GetComponent<Animator>();

        // Add and configure the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = footstepSound;
        audioSource.spatialBlend = 1.0f; // Fully 3D sound
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Check if the "Walk" animation is active
        if (animController.GetBool("Walk") && !audioSource.isPlaying)
        {
            audioSource.Play(); // Play the footstep sound
        }
        else if (!animController.GetBool("Walk") && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the sound when not walking
        }
    }
}

