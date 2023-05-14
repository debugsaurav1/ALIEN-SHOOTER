using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public ParticleSystem explosionEffect;
	//public UIManager manager;
	//private int playerLives = 3;
	// Start is called before the first frame update
	void Start()
	{
		//manager = GetComponent<UIManager>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(-0.0025f, 0, 0);

	}
	private void OnTriggerEnter(Collider collidedwith)
	{

		if (collidedwith.gameObject.CompareTag("Player"))
		{
			
			//Instantiate(explosionEffect.gameObject, gameObject.transform.position, gameObject.transform.rotation);
		
			print("Hit the player by powerup");
			//PlayerMove.healthValue -= 1;
		
			Destroy(gameObject);

			//if (playerLives < 1)
			//{
			//	Destroy(collidedwith.gameObject);
			//}
		}


	}


}
