
using System.Collections;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
	public GameObject enemy;
	private void Update()
	{
		if (GameObject.Find("Enemy") ==null)
		{
			Instantiate(enemy, new Vector3(12, 3, 0), Quaternion.identity);
			print("Here");
		}
	}
	
}
