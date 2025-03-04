using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject Explosion; // Assign the explosion particle system prefab
    public GameObject debrisPrefab; // Assign the broken barrel debris prefab

    private void OnCollisionEnter(Collision collision)
{
    // Check if the collision is with a bullet
    if (collision.gameObject.CompareTag("Bullet"))
    {
        Explode();
    }
}

    public void Explode()
    {
        //Instantiate explosion effect at the barrel's position
        Instantiate(Explosion, transform.position, Quaternion.identity);

        // Instantiate debris and remove the barrel
        Instantiate(debrisPrefab, transform.position, transform.rotation);
        Destroy(gameObject); // Remove the barrel
    }
}

