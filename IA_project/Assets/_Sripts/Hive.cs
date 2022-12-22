using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public GameObject flocking;
    static int numBee = 10;
    public int tankSize = 5;
    public GameObject[] allBees = new GameObject[numBee];
    // Start is called before the first frame update
    void Start()
    {
        CreateObgect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateObgect()
    {

        for (int i = 0; i < numBee; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
            Random.Range(-tankSize, tankSize),
            Random.Range(-tankSize, tankSize));
            allBees[i] = (GameObject)Instantiate(flocking, pos, Quaternion.identity);
        }
    }
}
