using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePowerupPoint : MonoBehaviour
{
	public GameObject[] powerup;
	public Transform spawnPoint;
	int direction = -1;
	float speed = 0.005f;
	float timer = 0f;
	private int count;

	// Start is called before the first frame update
	void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(0, direction * speed, 0);

		if (transform.position.y <= -4.0f)
		{
			direction = 1;
		}
		else if (transform.position.y >= 4.0f)
		{
			direction = -1;
		}
		InstanciatePowerup();

	}
	private void InstanciatePowerup()
	{
		int count = powerupCounter();
		timer += Time.deltaTime;

		GameObject selectedPowerup = powerup[Random.Range(0, powerup.Length)];
		if (timer > 12.0f && count <= 1)
		{
			Instantiate(selectedPowerup, spawnPoint.position, Quaternion.identity);
			timer = 0f;
		}
	}
	private int powerupCounter()
	{

		GameObject[] powerupCount = GameObject.FindGameObjectsWithTag("Powerup");
		count = powerupCount.Length;
		return count;
	}
}
