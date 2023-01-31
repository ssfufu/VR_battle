using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemyAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private NavMeshAgent nma;


    
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(player.transform.position);

        
    }
}
