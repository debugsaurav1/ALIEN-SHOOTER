using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteriod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider collidedwith)
	{
        if (collidedwith.gameObject.CompareTag("Player"))
        {
            GameObject[] astroidsAvailable = GameObject.FindGameObjectsWithTag("Astroid");
            foreach (GameObject astroid in astroidsAvailable)
            {
                Destroy(astroid);
            }
			print("Hit the death powerup");
		}
    }
}
