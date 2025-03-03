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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}
