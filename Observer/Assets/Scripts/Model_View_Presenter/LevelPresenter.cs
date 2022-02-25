using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] LevelModel level;
    [SerializeField] Text displayText;
    [SerializeField] Text experienceText;
    [SerializeField] Button increaseXPButton;

    private void Start()
    {
        increaseXPButton.onClick.AddListener(GainExperience);
        level.onExperienceChange += UpdateUI;
        UpdateUI();
    }

    private void GainExperience()
    {
        level.GainExperience(10);
    }

    private void UpdateUI()
    {
        displayText.text = $"Level: {level.GetLevel()}";
        experienceText.text = $"Experience: {level.GetExperience()}";
    }
}
