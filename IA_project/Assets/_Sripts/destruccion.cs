using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruccion : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.CompareTag("Treasure"))
        {
            Destroy(collision.gameObject);

        }
    }
}
