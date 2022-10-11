using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runner : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject[] waypoints;
    int patrolWP = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) Patrol();
    }
    void Patrol()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;
        Seek(waypoints[patrolWP].transform.position);
    }
    void Seek(Vector3 position)
    {
        agent.destination = target.transform.position;
    }
}
