using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100;
    public float currentHealth;
    public AudioSource damageSound;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        healthSlider.interactable = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        PlayDamageSound();
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }

    void PlayDamageSound()
    {
        if (damageSound != null)
        {
            damageSound.Play();
        }
    }
}
