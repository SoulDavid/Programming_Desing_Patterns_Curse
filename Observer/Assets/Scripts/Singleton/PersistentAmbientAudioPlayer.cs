using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton, solo cuando sea uno solo, y asi puedan acceder todos a ese value
public class PersistentAmbientAudioPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void FadeNewMusic()
    {
    }

}
