using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public GameObject flocking;
    static int numFish = 10;
    public int tankSize = 5;
    public GameObject[] allFish = new GameObject[numFish];
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

        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
            Random.Range(-tankSize, tankSize),
            Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(flocking, pos, Quaternion.identity);
        }
    }
}
