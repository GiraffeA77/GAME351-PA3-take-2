using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighteningAudio : MonoBehaviour
{
    new public ParticleSystem particleSystem;
    public AudioSource audioSource;

    void Start()
    {
        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        var emission = particleSystem.emission;
        emission.enabled = true;

        particleSystem.Play();
    }

    void Update()
    {
        if (particleSystem.isEmitting && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}


