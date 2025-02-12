﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public void PlayGame(string playGameLevel)
    {
        Application.LoadLevel(playGameLevel);
    }
    public void ExplainGame(string playGameLevel)
    {
        Application.LoadLevel(playGameLevel);
    }
    public void BackMenu()
    {
        Scene scene = SceneManager.GetActiveScene();

        int curScene = scene.buildIndex;

        int backScene = curScene - 1;

        SceneManager.LoadScene(backScene);
    }
}
