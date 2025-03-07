using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditTaunts : MonoBehaviour
{
    // Define the audio source for the bandit
    public AudioSource banditSource;

    // Define the taunts for the bandit
    public AudioClip[] banditTaunts;

    // List of other bandits
    public List<BanditTaunts> otherBandits;

    private void Start()
    {
        // Start the coroutine for handling taunts
        StartCoroutine(HandleTaunts());
    }

    private IEnumerator HandleTaunts()
    {
        while (true)
        {
            // Play a random taunt for the bandit if no other bandits are active
            if (!AnyOtherBanditActive())
            {
                PlayTaunt();
            }

            // Wait for a random delay between 10-30 seconds
            float delay = Random.Range(10f, 30f);
            yield return new WaitForSeconds(delay);
        }
    }

    private bool AnyOtherBanditActive()
    {
        // Check if any other bandits are currently playing a taunt
        foreach (var bandit in otherBandits)
        {
            if (bandit != null && bandit.banditSource.isPlaying)
            {
                return true;
            }
        }
        return false;
    }

    private void PlayTaunt()
    {
        if (banditTaunts.Length > 0)
        {
            // Select a random taunt and play it
            AudioClip taunt = banditTaunts[Random.Range(0, banditTaunts.Length)];
            banditSource.clip = taunt;
            banditSource.Play();
        }
    }

    public void RemoveBanditFromList(BanditTaunts bandit)
    {
        if (otherBandits.Contains(bandit))
        {
            otherBandits.Remove(bandit);
        }
    }
}



