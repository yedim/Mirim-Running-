using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public string playGameLevel;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Application.LoadLevel(playGameLevel);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel(playGameLevel);
        }
    }
}
