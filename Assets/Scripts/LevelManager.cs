using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    PointsKeeper pointsKeeper;
    void Awake()
    {
        pointsKeeper = FindObjectOfType<PointsKeeper>();
    }
    public void LoadGame()
    {
        pointsKeeper.ResetScore();
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
        
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
