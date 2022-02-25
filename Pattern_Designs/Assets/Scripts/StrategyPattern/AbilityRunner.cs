using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    [SerializeField] IAbility currentAbility = new RageAbility();
    
    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

//Todo es público dentro de las interfaces
public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class RageAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Rage activated");
    }
}

public class FireAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class HealAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here! Eat This");
    }
}