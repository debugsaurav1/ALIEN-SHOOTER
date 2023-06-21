using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
	private bool wasPaused = false;
	private CharacterController characterController;
	public float playerSpeed = 1;
	public GameObject bulletPrefab;
	public Transform firePoint;
	public GameObject life1, life2, life3, gameOver, restartButton;
	public static int healthValue;


	//public HitCounter hitCounter;
	// Start is called before the first frame update
	void Start()
	{
		healthValue = 3;
		life1.gameObject.SetActive(true);
		life2.gameObject.SetActive(true);
		life3.gameObject.SetActive(true);
		characterController = GetComponent<CharacterController>();  
	}

	// Update is called once per frame

	void Update()
	{
		if (UIManager.GameIsPaused && !wasPaused) 
		{ 
			wasPaused = true;
			Time.timeScale = 1;
			UIManager.GameIsPaused = false;
		}

		else if (!UIManager.GameIsPaused && wasPaused)
		{// Code here will run once when the game is resumed
			Debug.Log("Game resumed");
			wasPaused = false;
		}
		if (!UIManager.GameIsPaused)
		{
			healthUpdate();
			shoot();
			float vertical = Input.GetAxis("Vertical");
			float horizontal = Input.GetAxis("Horizontal");

			Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
			characterController.Move(direction * playerSpeed * Time.deltaTime);
		}
		
	}

	private void healthUpdate()
	{
		if (healthValue > 3)
		{
			healthValue = 3;
		}
		switch (healthValue) 
		{
		case 3:
				life1.gameObject.SetActive(true);
				life2.gameObject.SetActive(true);
				life3.gameObject.SetActive(true);
				break;
		case 2:
				life1.gameObject.SetActive(true);
				life2.gameObject.SetActive(true);
				life3.gameObject.SetActive(false);
				break;
		case 1:
				life1.gameObject.SetActive(true);
				life2.gameObject.SetActive(false);
				life3.gameObject.SetActive(false);
				break;
		case 0:
				life1.gameObject.SetActive(false);
				life2.gameObject.SetActive(false);
				life3.gameObject.SetActive(false);
				
				//pauseGameTime();
				UIManager.GameIsPaused = true;
				UIManager.instance.PauseGameOver();
				break;
		}

	}
	void pauseGameTime()
	{
		gameOver.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
		Time.timeScale = 0f;
	}
	private void shoot()
	{

		if (Input.GetButtonDown("Fire1"))
		{
			Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
			FindObjectOfType<AudioManager>().Play("Laser3");
		}
	}
	public void ResetTimeScale()
	{
		Time.timeScale = 1f;
	}
}
