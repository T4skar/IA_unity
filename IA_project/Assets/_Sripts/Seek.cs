using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seek : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject Runner;
    public float EnemyDistanceRun = 4.6f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Runner.transform.position);


        if (distance < EnemyDistanceRun)
        {

            Vector3 DirToSeeker = transform.position - Runner.transform.position;
            Vector3 newPos = transform.position - DirToSeeker;
            _agent.SetDestination(newPos);
        }
    }
}
