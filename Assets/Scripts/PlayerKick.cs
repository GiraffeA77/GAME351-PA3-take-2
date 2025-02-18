using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    public Animator animator;
    public float kickForce = 10f;
    public float kickRadius = 1.5f;
    public LayerMask kickableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformKick();
        }
    }

    void PerformKick()
    {
        int randomKick = Random.Range(0, 3);
        animator.SetInteger("KickType", randomKick);
        animator.SetTrigger("Kick");

        Collider[] hitObjects = Physics.OverlapSphere(transform.position + transform.forward, kickRadius, kickableLayer);

        foreach (Collider hit in hitObjects)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 kickDirection = hit.transform.position - transform.position;
                rb.AddForce(kickDirection.normalized * kickForce, ForceMode.Impulse);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, kickRadius);
    }
}
