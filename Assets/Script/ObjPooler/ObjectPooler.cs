using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public class Pool
    {
        public GameObject prefab;
        public Queue<GameObject> pool;

        public Pool(GameObject obj)
        {
            prefab = obj;
            pool = new Queue<GameObject>();
        }
    }

    Dictionary<string, Pool> poolStash;

    [System.Serializable]
    public class PoolRef
    {
        public string tag;
        public GameObject obj;
        public int count;
    }

    public List<PoolRef> poolRefList;
    public static ObjectPooler instance;

    private void Start()
    {
        //Initialize singleton for object pooler
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        poolStash = new Dictionary<string, Pool>();

        //Initialize Pooler
        foreach (PoolRef poolRef in poolRefList)
        {
            Pool newPool = new Pool(poolRef.obj);
            //add new pool to dictionary
            poolStash.Add(poolRef.tag, newPool);

            for (int i = 0; i < poolRef.count; i++)
            {
                GameObject spawnedObject = Instantiate(poolRef.obj);
                poolStash[poolRef.tag].pool.Enqueue(spawnedObject);
                spawnedObject.SetActive(false);
            }
        }
    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        //Create a new object when the pool is empty
        if (poolStash[tag].pool.Count == 0)
        {
            OnPoolEmpty(tag);
        }
        GameObject borrowedObject = poolStash[tag].pool.Dequeue();
        //set game object to desired position and rotation, also enable it
        borrowedObject.transform.position = position;
        borrowedObject.transform.rotation = rotation;
        borrowedObject.SetActive(true);
    }

    public void ReturnToPool(string tag, GameObject returnedObject)
    {
        returnedObject.SetActive(false);
        poolStash[tag].pool.Enqueue(returnedObject);
    }

    private void OnPoolEmpty(string tag)
    {
        //spawn new obj
        GameObject newObject = Instantiate(poolStash[tag].prefab);
        poolStash[tag].pool.Enqueue(newObject);
    }
}

