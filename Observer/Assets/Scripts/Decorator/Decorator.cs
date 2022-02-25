using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorator : MonoBehaviour
{
    [SerializeField] IAbilityDecorator currentAbility = new DelayedDecorator(new RageAbilityDecorator());
    
    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

//Todo es público dentro de las interfaces
public interface IAbilityDecorator
{
    void Use(GameObject currentGameObject);
}

public class RageAbilityDecorator : IAbilityDecorator
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Rage activated");
    }
}

public class FireAbilityDecorator : IAbilityDecorator
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class HealAbilityDecorator : IAbilityDecorator
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here! Eat This");
    }
}

public class DelayedDecorator : IAbilityDecorator
{
    private IAbilityDecorator wrappedAbility;

    public DelayedDecorator(IAbilityDecorator wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        wrappedAbility.Use(currentGameObject);
    }
}