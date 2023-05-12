using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("destroyer"))
        {
            Destroy(collision.gameObject);
           // print(collision.gameObject.name);
        } 
    }
}
