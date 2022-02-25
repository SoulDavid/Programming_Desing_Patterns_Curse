using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton, solo cuando sea uno solo, y asi puedan acceder todos a ese value
public class AmbientAudioPlayer : MonoBehaviour
{
    private static AmbientAudioPlayer instance = null;

    public static AmbientAudioPlayer GetInstance()
    {
        if (instance == null)
            instance = new AmbientAudioPlayer();

        return instance;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    }

    //Esto hace que solo haya uno y no se creen mas de uno
    private AmbientAudioPlayer() { }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
