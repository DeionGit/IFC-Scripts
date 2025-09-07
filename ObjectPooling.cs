using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooling instance;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolObstacule = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        #region Singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion
    }
    void Start()
    {
        Invoke("CreatePoolObstacules", 0.5f);
    }
    void CreatePoolObstacules()
    {
        poolObstacule = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolObstacule.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent)
    {
        if (!poolObstacule.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesnt excist.");
            return null;
        }
        GameObject objectToSpawn = poolObstacule[tag].Dequeue();

        objectToSpawn.SetActive(true);

        if (parent != null)
        {
           objectToSpawn.transform.SetParent(parent);
        }
        
        objectToSpawn.transform.localPosition = position;
        objectToSpawn.transform.rotation = rotation;

        poolObstacule[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
   
}
