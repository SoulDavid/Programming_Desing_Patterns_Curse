using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Libreria para los eventos de Unity
using UnityEngine.Events;
using System;

public class Level : MonoBehaviour
{
    [SerializeField] int pointsPerLevel = 200;
    //Este evento se introduce a traves del inspector
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints = 0;

    //Evento a través de código
    public event Action onLevelUpAction;

    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int Level = GetLevel();
        experiencePoints += points;

        if(GetLevel() > Level)
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
