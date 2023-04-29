using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float bulletSpeed = 2f; 
	public float destroyTime = 2.5f;
	public int damageAmount = 10;
	private void Start()
	{
		Destroy(gameObject, destroyTime);
	}
	void Update()
	{
		float distance = bulletSpeed * Time.deltaTime; // distance to move this frame
		Vector3 movement = new Vector3(distance, 0f, 0f); // movement vector
		transform.Translate(movement); // move the object
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider == null) 
		{
			Debug.Log("" + collision);
		}
		Destroy (gameObject);		
	}
	/*private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			// get the enemy's health script
			Enemy enemyHealth = other.GetComponent<Enemy>();

			// apply damage to the enemy's health
			if (enemyHealth != null)
			{
				enemyHealth.TakeDamage(damageAmount);
			}

			// destroy the bullet object
			Destroy(gameObject);
		}
	}*/
}
