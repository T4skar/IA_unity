using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIVision : MonoBehaviour
{
	private NavMeshAgent _agent;
	public GameObject Runner;
	public Camera frustum;
	public LayerMask mask;

	void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
	}
	void Update () {
		Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);
		//float distance = Vector3.Distance(transform.position, Runner.transform.position);

		foreach (Collider col in colliders)
		{
			if(col.gameObject != gameObject && GeometryUtility.TestPlanesAABB(planes, col.bounds))
			{
				RaycastHit hit;
				Ray ray = new Ray();
				ray.origin = transform.position;
				ray.direction = (col.transform.position - transform.position).normalized;
				ray.origin = ray.GetPoint(frustum.nearClipPlane);

				if (Physics.Raycast(ray, out hit, frustum.farClipPlane, mask))
				{ }
					if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
						Vector3 DirToSeeker = transform.position - Runner.transform.position;
						Vector3 newPos = transform.position - DirToSeeker;
						_agent.SetDestination(newPos);
					}

				
					
						// Your code!!
			}
		}
	}
}