using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    class Pool
    {
        public string tag;
        public GameObject prefab;
        public  int size;
    }

    public static ObjectPool instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject createdObj = Instantiate(pool.prefab);
                createdObj.SetActive(false);
                objPool.Enqueue(createdObj);
            }

            poolDictionary.Add(pool.tag, objPool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag)) return null;

        GameObject objectFromPool = poolDictionary[tag].Dequeue();

        objectFromPool.SetActive(true);
        objectFromPool.transform.position = position;
        objectFromPool.transform.rotation = rotation;

        IPooledObject pooledObject = objectFromPool.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            pooledObject.OnSpawnObject();
        }

        poolDictionary[tag].Enqueue(objectFromPool);

        return objectFromPool;
    }
}
