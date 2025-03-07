using System.Collections;
using UnityEngine;

public class BanditWandering : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float wanderInterval = 5f;
    public float speed = 3f;
    public GameObject bandit;

    Animator animController;
    CharacterController characterController;
    private Vector3 targetPosition;

    void Start()
    {
        animController = bandit.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        StartCoroutine(Wander());
    }

    void Update()
    {
        if (targetPosition != Vector3.zero)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            float step = speed * Time.deltaTime;

            characterController.Move(direction * step);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * speed);

            animController.SetBool("Walk", true);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = Vector3.zero;
                animController.SetBool("Walk", false);
            }
        }
        else
        {
            animController.SetBool("Walk", false);
        }
    }

    IEnumerator Wander()
    {
        while (true)
        {
            targetPosition = new Vector3(
                Random.Range(transform.position.x - wanderRadius, transform.position.x + wanderRadius),
                transform.position.y,
                Random.Range(transform.position.z - wanderRadius, transform.position.z + wanderRadius)
            );

            yield return new WaitForSeconds(wanderInterval);
        }
    }
}
