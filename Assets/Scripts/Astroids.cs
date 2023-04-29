using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 65.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.RotateAround(transform.position, transform.up, (float)Space.Self * Time.deltaTime * rotationSpeed);
	}

}
