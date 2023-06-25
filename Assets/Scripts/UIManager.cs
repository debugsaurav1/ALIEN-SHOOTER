using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public  bool GameIsPaused =false;
	public GameObject PauseMenuUI;
	public GameObject GameOverUI;
	public TMP_Text scoreText;
	//public TMP_Text highScoreText;

	private int score = 0;
	
	public static UIManager instance;
	private PlayerMove playerMoveScript;
	private void Awake()
	{
		instance = this;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else 
			{
				Pause();
			}
		}
	}
	public void Resume() 
	{
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		GameIsPaused = true;
	}
	public void Pause() 
	{
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = false;
	}
	public void PauseGameOver()
	{
		GameOverUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = true;
	}
	public void Restart()
	{
		SceneManager.LoadScene("GameScene");
		//PauseMenuUI.SetActive(false);
		//Time.timeScale = 1;
		//GameIsPaused = false;
	}

	//public void LoadMenu() 
	//{
	//	Debug.Log("Loading Menu....");
	//	SceneManager.LoadScene("MenuScene");
	//}
	public void QuitGame()
	{
		Debug.Log("Quitting");
		Application.Quit();
	}

	private void Start()
	{
		scoreText.text = "Score : 0" + score.ToString();
		
	}
	public void UpdateScoreText( int hitCount)
	{
		score += hitCount;
		scoreText.text = "Score : " +score.ToString();
	}

	
}
