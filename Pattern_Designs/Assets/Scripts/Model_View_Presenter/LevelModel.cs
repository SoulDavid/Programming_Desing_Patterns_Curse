using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelModel : MonoBehaviour
{
    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints = 0;

    public event Action onLevelUpAction;
    public event Action onExperienceChange;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {  
    }

    public void GainExperience(int points)
    {
        int Level = GetLevel();
        experiencePoints += points;

        if(onExperienceChange != null)
        {
            onExperienceChange();
        }

        if (GetLevel() > Level)
        {
            onLevelUp.Invoke();

            //https://nosuchstudio.medium.com/why-are-null-coalescing-operators-evil-in-unity-16f5a88d6071
            if (onLevelUpAction != null)
                onLevelUpAction();
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}
