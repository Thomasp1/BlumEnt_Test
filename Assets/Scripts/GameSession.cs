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

    public void ProcessPlayerDamage()
    {
        if(playerLives > 1)
        {
            playerLives --;
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        scoreText.text =  playerScore.ToString();
    }

    void Start() 
    {
        livesText.text = playerLives.ToString();
        scoreText.text =  playerScore.ToString();
    }

}
