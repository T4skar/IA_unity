using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centralita_de_mando : MonoBehaviour
{

    private WaitForSeconds wait = new WaitForSeconds(0.05f);   // 1 / 20
    delegate IEnumerator State();
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        //state = Wander;
    }

    
    // Update is called once per frame
    void Update()
    {
        
        //while (enabled)
        //{
        //    yield return StartCoroutine(state());
        //}
    }
    //IEnumerator Wander()
    //{
    //    Debug.Log("Wander state");

    //}
}
