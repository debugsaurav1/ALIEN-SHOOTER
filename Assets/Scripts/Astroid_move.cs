using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid_move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.0025f,0,0);
    }
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider == null)
		{
			Debug.Log("Collide" + collision);
		}
		Destroy(gameObject);
	}

}
