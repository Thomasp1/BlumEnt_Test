using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameSession gameSession;
    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
    public void LoadGame()
    {
        gameSession.ResetScore();
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
        
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
