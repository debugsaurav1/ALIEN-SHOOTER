using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private CharacterController characterController;
	public float playerSpeed = 0;

	public GameObject bulletPrefab;
	public Transform firePoint;

	//public HitCounter hitCounter;
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

		Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
		characterController.Move(direction * playerSpeed * Time.deltaTime);
		int bulletCounter = BulletCounter();
		if (Input.GetButtonDown("Fire1") && bulletCounter < 20)
		{
			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
		}
	}
	private int BulletCounter()
	{
		GameObject[] allObjects = GameObject.FindGameObjectsWithTag("bullet");
		int count = allObjects.Length;
		return count;
	}
	void OnBulletHit(int count) 
	{
		int score = count;
		//BroadcastMessage("MyMessage", count, SendMessageOptions.RequireReceiver);
		print("Counter from PlayerMove" + score);
	}


}
