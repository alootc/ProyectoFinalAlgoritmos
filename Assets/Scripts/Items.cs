using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    public static Items instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public ItemData[] prefabs;

    public GameObject GetPrefab(string id)
    {
        for( int i = 0; i < prefabs.Length; i++)
        {
            if (id == prefabs[i].id)
            {
                return prefabs[i].prefab;
            } 
        }
        return null;
    }

    [System.Serializable]
    public class ItemData
    {
        public string id;
        public GameObject prefab;
    }


}
