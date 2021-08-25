using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pooledObject;

    public int pooledAmmount;

    List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < pooledAmmount; i++)
        {
            GameObject platform = (GameObject) Instantiate(pooledObject);
            platform.SetActive(false);
            pooledObjects.Add(platform);
        }
    }

    public GameObject GetGameObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject platform = (GameObject)Instantiate(pooledObject);
        platform.SetActive(false);
        pooledObjects.Add(platform);
        return platform;
    }
}
