using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour {

    public Image fillImage;
    public float timeAmt = 100f;
    public float time;
    public bool updateTimer = true;


	// Use this for initialization
	void Start () {
        time = timeAmt;
	}
	
	// Update is called once per frame
	void Update () {

        if(time> 0 && updateTimer==true )
        {
            time -= Time.deltaTime;
            fillImage.fillAmount = time / timeAmt;
        }      
	}
    public void ResetHP()
    {
        time = timeAmt;
        fillImage.fillAmount = 1;
    }

}
