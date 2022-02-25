using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunnerCompositePattern : MonoBehaviour
{
    [SerializeField] IAbilityComposite currentAbility = new SequenceComposite(new IAbilityComposite[] {
        new HealAbilityComposite(),
        new RageAbilityComposite(),
        new DelayedComposite(new RageAbilityComposite())});


    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

//Todo es público dentro de las interfaces
public interface IAbilityComposite
{
    void Use(GameObject currentGameObject);
}

public class RageAbilityComposite : IAbilityComposite
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Rage activated");
    }
}

public class FireAbilityComposite : IAbilityComposite
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class HealAbilityComposite : IAbilityComposite
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here! Eat This");
    }
}

public class DelayedComposite : IAbilityComposite
{
    private IAbilityComposite wrappedAbility;

    public DelayedComposite(IAbilityComposite wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        wrappedAbility.Use(currentGameObject);
    }
}

public class SequenceComposite : IAbilityComposite
{
    private IAbilityComposite[] children;

    public SequenceComposite(IAbilityComposite[] children)
    {
        this.children = children;
    }

    public void Use (GameObject currentGameObject)
    {
        foreach(var child in children)
        {
            child.Use(currentGameObject);
        }
    }
}
