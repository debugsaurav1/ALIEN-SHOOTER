using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid_move : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    public UIManager manager;
    private int playerLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.0025f,0,0);
        
    }
	private void OnCollisionEnter(Collision collidedwith)
	{
        
        if (collidedwith.gameObject.CompareTag ("Player"))
        {
           // Debug.Log(explosionEffect);
            Instantiate(explosionEffect.gameObject, gameObject.transform.position, gameObject.transform.rotation);
            //explosionEffect.Play();
            print("Hit the player");
			//Destroy(collidedwith.gameObject);
			Destroy(gameObject);
            playerLives--;
           // manager.updateLives(playerLives);

            if (playerLives < 1)
            {
				Destroy(collidedwith.gameObject);
			}
		}

        
	}

    
}
