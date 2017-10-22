using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCreate : MonoBehaviour {

    public Transform Background;
    public GameObject Player;
    public string bgImgname;
    public int width;
    private bool isbgCreate;
    private bool isFirst = true;
    Transform newBg;

    // Use this for initialization
    void Start () {
        isbgCreate = false;
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < Player.transform.position.x && isbgCreate == false)
        {
            if (isFirst)
            {
                newBg = Instantiate(Background);
                isFirst = false;
            }
            newBg.transform.localPosition = new Vector3(transform.position.x + 80, 0, 10);
            newBg.gameObject.SetActive(true);
            isbgCreate = true;
        }
        if (transform.position.x < Player.transform.position.x-70)
        {
            transform.position = new Vector3(newBg.position.x + 80, 0, 10);
            isbgCreate = false;
        }
    }
}
