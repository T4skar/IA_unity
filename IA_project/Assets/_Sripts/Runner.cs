using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine.AI;
using UnityEngine;
public class Runner : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject Seeker;
    public PathCreator pathCreator;
    public float speed = 5;
    public float EnemyDistanceRun = 4.6f;

    float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (pathCreator != null)
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
            _agent.destination = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        };
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Seeker.transform.position);
        if (distance < EnemyDistanceRun)
        {

            Vector3 DirToSeeker = transform.position - Seeker.transform.position;
            Vector3 newPos = transform.position + DirToSeeker;
            _agent.SetDestination(newPos);
        }
        else if (distance > EnemyDistanceRun)
        {
            if (_agent.remainingDistance > 0.2f)
            {
                distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
                _agent.destination = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            }
            else
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                if (pathCreator != null)
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                }
            }
        }
    }
}
