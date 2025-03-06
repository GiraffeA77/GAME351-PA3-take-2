using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource defaultTrack;
    public AudioSource suspenseTrack;
    public AudioSource fightTrack;

    public GameObject player;
    public GameObject supplyStore;

    private float shootingTimer;
    private float shootingCooldown = 10f; // Adjust cooldown duration as needed

    void Update()
    {
        if (PlayerNearSupplyStore())
        {
            PlayTrack(suspenseTrack);
        }
        else if (PlayerIsShooting())
        {
            PlayTrack(fightTrack);
            shootingTimer = shootingCooldown; // Reset the shooting timer
        }
        else if (shootingTimer > 0)
        {
            shootingTimer -= Time.deltaTime;
            PlayTrack(fightTrack);
        }
        else
        {
            PlayTrack(defaultTrack);
        }
    }

    private bool PlayerNearSupplyStore()
    {
        float distance = Vector3.Distance(player.transform.position, supplyStore.transform.position);
        return distance < 10f; // Adjust range as needed
    }

    private bool PlayerIsShooting()
    {
        // Add logic to detect player shooting
        return Input.GetKeyDown(KeyCode.F); // Example for left-click shooting
    }

    private void PlayTrack(AudioSource trackToPlay)
    {
        if (!trackToPlay.isPlaying)
        {
            StopAllTracks();
            trackToPlay.Play();
        }
    }

    private void StopAllTracks()
    {
        defaultTrack.Stop();
        suspenseTrack.Stop();
        fightTrack.Stop();
    }
}
