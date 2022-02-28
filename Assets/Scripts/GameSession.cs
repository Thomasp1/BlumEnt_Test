using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;

    int playerScore = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    static GameSession instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DamageLives(int damageToAdd)
    {
        playerLives -= damageToAdd;
        livesText.text = playerLives.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        scoreText.text =  playerScore.ToString();
    }

    public void ResetScore()
    {
        playerScore = 0;
    }

    void Start() 
    {
        livesText.text = playerLives.ToString();
        scoreText.text =  playerScore.ToString();
    }

}
