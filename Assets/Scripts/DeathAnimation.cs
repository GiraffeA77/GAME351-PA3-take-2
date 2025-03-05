using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
     private Animator animator;
    public string deathTrigger = "Die";
    public float destroyAfterAnimation = 2f; // Time before the GameObject is destroyed

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(deathTrigger);
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private System.Collections.IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(destroyAfterAnimation);
        Destroy(gameObject);
    }
}