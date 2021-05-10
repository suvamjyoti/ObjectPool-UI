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
    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    private Queue<GameObject> gameObjectQueue = new Queue<GameObject>();

    private static GenericObjectPool Instance;

    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````
    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````
    private void Awake()
    {
        Instance = this;
    }

    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````
    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Start()
    {

        foreach (var item in PoolList)
        {
            for (int i = 0; i < item.size; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                gameObjectQueue.Enqueue(obj);
            }
            poolDictionary.Add(item.name, gameObjectQueue);
        }

    }

    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````
    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````

    internal GameObject spawner(string key, Transform SpawnTransform)
    {

        GameObject obj = poolDictionary[key].Dequeue();                
        obj.transform.position = SpawnTransform.position;

        obj.SetActive(true);                                            
        poolDictionary[key].Enqueue(obj);                               

        return obj;                                                     
    }


}