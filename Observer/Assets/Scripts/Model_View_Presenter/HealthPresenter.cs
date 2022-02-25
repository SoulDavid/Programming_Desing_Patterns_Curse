using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] HealthModel health;
    [SerializeField] Image healthBar;

    private void Start()
    {
        health.onHealthChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = health.GetHealth() / health.GetFullHealth();
    }
}
