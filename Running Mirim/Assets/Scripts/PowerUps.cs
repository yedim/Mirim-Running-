using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    public bool doublePoints;
    public bool safeMode;

    public float powerupLength; //몇 초간 지속

    private PowerUpManager thePowerupManager;
	// Use this for initialization
	void Start () {
        thePowerupManager = FindObjectOfType<PowerUpManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Player")
        {
            thePowerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
        }
        gameObject.SetActive(false);
    }
}
