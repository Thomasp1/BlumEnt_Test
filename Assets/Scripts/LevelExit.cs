using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    float levelLoadDelay = 0.5f;
    LevelManager levelManager;
    void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.tag == "Player")
        {
            levelManager = FindObjectOfType<LevelManager>();
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        levelManager.LoadNextLevel();
    }
}