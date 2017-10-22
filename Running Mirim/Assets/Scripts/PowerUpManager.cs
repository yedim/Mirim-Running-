using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;

    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPointsPerSecond;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;
    private PlayerController thePlayerController;


    // Use this for initialization
    void Start (){
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        thePlayerController = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if(doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2.75f;
                theScoreManager.shouldDouble = true;
            }

            if(safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0f;
            }

            if(powerupLengthCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;
                thePlatformGenerator.distanceBetweenMax = 10;
                thePlatformGenerator.distanceBetweenMin = 13;
                thePlayerController.moveSpeed = 12;
                powerupActive = false;
            }
        }
	}

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;

        if(safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if ((spikeList[i].gameObject.name.Contains("Clone") || spikeList[i].gameObject.name.Contains("Spike")) && !spikeList[i].gameObject.name.Contains("Jelly") && !spikeList[i].gameObject.name.Contains("Ground"))
                {
                    spikeList[i].gameObject.SetActive(false);
                    thePlatformGenerator.distanceBetweenMax = 5;
                    thePlatformGenerator.distanceBetweenMin = 5;
                    thePlayerController.moveSpeed = 40;


                }
            }
        }
        

        powerupActive = true;
    }
}
