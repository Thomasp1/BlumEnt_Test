using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsPresenter : MonoBehaviour
{
    PointsKeeper pointsKeeper;
    [SerializeField] TextMeshProUGUI scoreText;
    private void Start() {
        pointsKeeper = FindObjectOfType<PointsKeeper>();
        pointsKeeper.onPointsChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = pointsKeeper.GetScore().ToString();
    }
}
