using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{

    private int maxVelocity = 2;
    private int turnSpeed = 2;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Seek
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;    // (x, z): position in the floor
        // Flee
        //Vector3 direction = transform.position - target.transform.position;

        Vector3 movement = direction.normalized * maxVelocity;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                                      Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * maxVelocity * Time.deltaTime;
    }
}
