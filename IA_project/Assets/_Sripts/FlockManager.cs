using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour {

    public static FlockManager flockManeger;
    public GameObject beePrefab;
    public int numBee = 20;
    public GameObject[] allBee;
    public Vector3 flyLimits = new Vector3(5.0f, 5.0f, 5.0f);
    public Vector3 goalPos = Vector3.zero;

    
    public float minSpeed;
    public float maxSpeed;
    public float neighbourDistance;
    public float rotationSpeed;

    void Start() {

        allBee = new GameObject[numBee];

        for (int i = 0; i < numBee; ++i) {

            Vector3 pos = this.transform.position + new Vector3(
                Random.Range(-flyLimits.x, flyLimits.x),
                Random.Range(-flyLimits.y, flyLimits.y),
                Random.Range(-flyLimits.z, flyLimits.z));

            allBee[i] = Instantiate(beePrefab, pos, Quaternion.identity);
        }

        flockManeger = this;
        goalPos = this.transform.position;
    }


    void Update() {

        if (Random.Range(0, 1000) < 10) {

            goalPos = this.transform.position + new Vector3(
                Random.Range(-flyLimits.x, flyLimits.x),
                Random.Range(-flyLimits.y, flyLimits.y),
                Random.Range(-flyLimits.z, flyLimits.z));
        }
    }
}