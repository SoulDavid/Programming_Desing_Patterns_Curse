using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    //[Tooltip("This prefab will only be spawned once and persisted between scenes.")]
    //[SerializeField] GameObject persistentObjectPrefab = null;

    //Si en vez de tener solo un objeto, tenemos una lista:
    [SerializeField] private List<PersistentObject> persistentsObjectPrefabs;

    //Booleano que indica si ha sido spawneado o no
    private static bool hasSpawned = false;

    private void Awake()
    {
        if (hasSpawned) return;
        SpawnPersistentObjects();
        hasSpawned = true;

    }

    private void SpawnPersistentObjects()
    {
        foreach(var persistentObjectPrefab in persistentsObjectPrefabs)
        {
            GameObject persistentObject = Instantiate(persistentObjectPrefab.prefab);
            persistentObject.name = persistentObjectPrefab.nameOfObject == null ? persistentObjectPrefab.prefab.name : persistentObjectPrefab.nameOfObject;
            DontDestroyOnLoad(persistentObject);
        }
    }

    //private void SpawnPersistentObjects()
    //{
    //    GameObject persistentObject = Instantiate(persistentObjectPrefab);
    //    DontDestroyOnLoad(persistentObject);
    //}
}

[System.Serializable]
public class PersistentObject
{
    public string nameOfObject;
    public GameObject prefab;
}
