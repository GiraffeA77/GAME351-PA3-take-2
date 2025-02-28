using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject Explosion; // Assign the explosion particle system prefab
    // public GameObject debrisPrefab; // Assign the broken barrel debris prefab

    public void Explode()
    {
        // Instantiate explosion effect at the barrel's position
        Instantiate(Explosion, transform.position, Quaternion.identity);

        // Instantiate debris and remove the barrel
        // Instantiate(debrisPrefab, transform.position, transform.rotation);
        Destroy(gameObject); // Remove the barrel
    }
}

