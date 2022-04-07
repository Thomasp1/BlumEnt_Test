using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsKeeper : MonoBehaviour
{

    private int playerScore = 0;

    static PointsKeeper instance;

    public event Action onPointsChange;

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

    public int GetScore()
    {
        return playerScore;
    }

    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        if (onPointsChange != null)
        {
            onPointsChange();
        }
    }

    public void ResetScore()
    {
        playerScore = 0;
        if (onPointsChange != null)
        {
            onPointsChange();
        }
    }

}
