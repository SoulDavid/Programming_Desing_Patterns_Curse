using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    [SerializeField] LevelModel ObserverSuscribe;
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    public event Action onHealthChange;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void OnEnable()
    {
        ObserverSuscribe.onLevelUpAction += ResetHealth;
    }

    private void OnDisable()
    {
        ObserverSuscribe.onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }

    private void ResetHealth()
    {
        currentHealth = fullHealth;

        if(onHealthChange != null)
        {
            onHealthChange();
        }
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            if (onHealthChange != null)
            {
                onHealthChange();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
