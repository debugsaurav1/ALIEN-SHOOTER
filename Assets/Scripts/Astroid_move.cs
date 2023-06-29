using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid_move : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    public UIManager manager;
    private int playerLives = 3;
	public float delay = 2f;
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
           
            Instantiate(explosionEffect.gameObject, gameObject.transform.position, gameObject.transform.rotation);
			FindObjectOfType<AudioManager>().Play("PlayerDamage");



			PlayerMove.healthValue -= 1;
            if (PlayerMove.healthValue <= 0)
            {
				FindObjectOfType<AudioManager>().Play("GameOver");
			}
			Destroy(gameObject);
            playerLives--;
            if (playerLives < 1)
            {
				
				Destroy(collidedwith.gameObject);
			}
		}
	}
}
