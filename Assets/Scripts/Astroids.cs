using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
	
	//private readonly float rotationSpeed = randomFloat;
    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		float randomSpeed = Random.Range(65.0f, 150.0f);
		transform.RotateAround(transform.position, transform.up, (float)Space.Self * Time.deltaTime * randomSpeed);
	}

}
