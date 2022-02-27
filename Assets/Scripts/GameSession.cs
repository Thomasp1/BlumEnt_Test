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

    void Start() 
    {
        livesText.text = playerLives.ToString();
        scoreText.text =  playerScore.ToString();
    }

}
