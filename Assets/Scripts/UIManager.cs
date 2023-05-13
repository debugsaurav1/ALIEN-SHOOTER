using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public TMP_Text scoreText;
	public TMP_Text highScoreText;

	private int score = 0;
	
	public static UIManager instance;
	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		scoreText.text = "Score : " + score.ToString();
		
	}


	public void UpdateScoreText( int hitCount)
	{
		score += hitCount;
		scoreText.text = "Score : " +score.ToString();
	}
}
