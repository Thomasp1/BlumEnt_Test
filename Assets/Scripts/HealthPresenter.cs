using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPresenter : MonoBehaviour
{

    [SerializeField] Health health;
    
    [SerializeField] TextMeshProUGUI livesText;

    private void Start() {
        health.onHealthChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        livesText.text = health.GetHealth().ToString();
    }
}
