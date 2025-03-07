using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditsShootingBack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform player;
    public float bulletSpeed = 15f;
    public float minFireRate = 30f; // Minimum time between shots
    public float maxFireRate = 60f; // Maximum time between shots
    public float minInaccuracyAngle = -10f;
    public float maxInaccuracyAngle = 10f;
    public LayerMask obstacleLayer;
    public AudioClip shootingSound;
    public AudioSource audioSource;
    public GameObject muzzleFlashEffect;
    public Animator animator; // Reference to the Animator component
    public float shootingAngleThreshold = 45f; // Angle threshold for shooting

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
        }
    }

    void ShootAtPlayer()
    {
        if (player == null) return;

        Vector3 directionToPlayer = (player.position - firePoint.position).normalized;
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(minInaccuracyAngle, maxInaccuracyAngle), 0);
        Vector3 inaccurateDirection = randomRotation * directionToPlayer;

        // Check if the player is in front of the bandit
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        if (angleToPlayer > shootingAngleThreshold) return;

        // Check if there is an obstacle between the bandit and the player
        if (Physics.Raycast(firePoint.position, inaccurateDirection, out RaycastHit hit, Mathf.Infinity, obstacleLayer))
        {
            if (hit.transform != player)
            {
                Debug.Log("Blocked by an obstacle: " + hit.transform.name);
                return; // Stop shooting if an obstacle is in the way
            }
        }

        // Instantiate bullet and apply force
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(inaccurateDirection));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = inaccurateDirection * bulletSpeed;
        }

        // Play shooting sound
        if (audioSource != null && shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        // Show muzzle flash effect
        if (muzzleFlashEffect != null)
        {
            GameObject flash = Instantiate(muzzleFlashEffect, firePoint.position, firePoint.rotation);
            Destroy(flash, 1f); // Destroy effect after 1 second
        }

        // Play shooting animation
        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }
    }
}
