using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    public Text resultScoreText;

    public float scoreCount;
    public float highScoreCount;
    public float resultScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool shouldDouble;


	// Use this for initialization
	void Start () {
		//if(PlayerPrefs.HasKey("HighScore"))
  //      {
  //          highScoreCount = PlayerPrefs.GetFloat("HighScore");
  //      }
	}
	
	// Update is called once per frame
	void Update () {

        if(scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("High Score ", highScoreCount);
        }
        scoreText.text = ""+ Mathf.Round(scoreCount);
        resultScoreText.text = scoreText.text;
        highScoreText.text = "High Score " + Mathf.Round(highScoreCount);

	}
    public void AddScore(int pointsToAdd)
    {
        if(shouldDouble)
        {
            pointsToAdd = pointsToAdd * 2;
        }
        scoreCount += pointsToAdd;
    }
}
