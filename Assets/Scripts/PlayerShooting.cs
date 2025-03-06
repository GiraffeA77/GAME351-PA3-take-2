using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    private bool isAiming = false;
    public AudioClip gunshotSound; // Assign gunshot sound in Inspector
    private AudioSource audioSource; // Reference to play the sound

    void Start()
    {
        // Configure AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = gunshotSound;
        audioSource.spatialBlend = 1.0f; // Fully 3D sound
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Check if "Ctrl" key is pressed to enter aiming mode
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isAiming = true;
            animator.speed = 0f; // Pause the animation
        }

        // Check if "Ctrl" key is released to exit aiming mode
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isAiming = false;
            animator.speed = 1f; // Resume the animation
        }

        // Shooting logic
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
        {
            if (!isAiming)
            {
                animator.SetTrigger("Aim");
            }
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Play gunshot sound
        audioSource.Play();

        // Instantiate bullet at firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply velocity in the player's forward direction
            rb.velocity = transform.forward * bulletSpeed;
        }
    }
}

