using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool : MonoBehaviour
{

    [Serializable]
    public class Pool
    {
        public string name;
        public int size;
        public GameObject prefab;
    }

    public Pool[] PoolList;
    //private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    private Queue<GameObject> gameObjectQueue = new Queue<GameObject>();

    public RectTransform parentObject;

    public static GenericObjectPool Instance;

    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````
    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````
    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;

        foreach (var item in PoolList)
        {
            for (int i = 0; i < item.size; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.transform.SetParent(parentObject, true);
                obj.SetActive(false);
                gameObjectQueue.Enqueue(obj);
            }
            //poolDictionary.Add(item.name, gameObjectQueue);
        }

    }

    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````
    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````

    internal GameObject spawner(string key, Transform SpawnTransform)
    {

        GameObject obj = gameObjectQueue.Dequeue();
        obj.transform.SetParent(parentObject, true);
        obj.transform.position = SpawnTransform.position;

        obj.SetActive(true);                                            
        gameObjectQueue.Enqueue(obj);                               

        return obj;                                                     
    }


}