using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemyAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackDelay = 3f;
    private NavMeshAgent nma;
    private float t = 0;
    
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        nma.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); // Move to player
        Animation(); // Set animation
        Attack(); // Attack player
    }

    private bool isInRange() // Check if player is in range
    {
        return nma.hasPath && nma.remainingDistance < nma.stoppingDistance;
    }

    private void Movement ()
    {
        nma.SetDestination(player.transform.position);
    }

    private void Animation ()
    {
        animator.SetBool("inRange", isInRange());
    }

    public void Attack()
    {
        if (isInRange())
        {
            t += Time.deltaTime;
            if (t >= attackDelay)
            {
                t = 0;
                animator.SetTrigger("Attack");
            }
        }
    }
}
