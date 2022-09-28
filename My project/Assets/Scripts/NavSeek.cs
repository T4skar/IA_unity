using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavSeek : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }
    void Seek()
    {
        agent.destination = target.transform.position;
    }
}
