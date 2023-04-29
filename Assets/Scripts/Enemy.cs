using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float enemySpeed = 2f;
	public GameObject enemyPrefab; // the prefab to use for the new enemy
	//public int maxHealth = 100;
	//private int currentHealth;

	// Start is called before the first frame update
	void Start()
    {
		//currentHealth = maxHealth;
	}

    // Update is called once per frame
    void Update()
    {
        MovementFuntion();
	}

    private void MovementFuntion()
    {
		float distance = enemySpeed * Time.deltaTime;
		Vector3 movement = new Vector3(-distance, 0, 0);
		transform.Translate(movement);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider == null)
		{
			Debug.Log("Collide" + collision);
		}
		Destroy(gameObject);
	}
	/*
	 * public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
	/*private void OnDestroy()
	{
		Instantiate(enemyPrefab, transform.position, Quaternion.identity);
	}*/
}
