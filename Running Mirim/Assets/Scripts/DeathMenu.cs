using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Scene scene = SceneManager.GetActiveScene();

        int curScene = scene.buildIndex;

        int backScene = curScene - 1;

        SceneManager.LoadScene(backScene);
    }
	
}
