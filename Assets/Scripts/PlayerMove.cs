using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private CharacterController characterController;
	public float playerSpeed = 0;

	public GameObject bulletPrefab;
	public Transform firePoint;

	// Start is called before the first frame update
	void Start()
	{
		characterController = GetComponent<CharacterController>();  
	}

	// Update is called once per frame

	void Update()
	{
	   
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		Vector3 direction = new Vector3(horizontal, vertical, 0 ).normalized;

		if (direction.magnitude >= 0.1f)
		{
	

			characterController.Move(direction * playerSpeed * Time.deltaTime);
		}

		if (Input.GetButtonDown("Fire1"))
		{
			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
			Debug.Log("Fire1 pressed");
		}
	}
}
