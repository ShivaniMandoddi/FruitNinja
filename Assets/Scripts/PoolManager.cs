using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    //public GameObject prefabToClone;
    public List<ObjectToPool> pools=new List<ObjectToPool>(); 
    //public int capacity;
    #endregion
    #region PRIVATE VARIABLES
    List<GameObject> pool=new List<GameObject>();          //To make a list of cloned objects
    #endregion
    #region SINGLETON
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new PoolManager();
                if(instance==null)
                {
                    GameObject container = GameObject.Find("PoolManager");
                    instance=container.GetComponent<PoolManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    #region MONOBEHAVIOUR METHODS

    void Start()
    {
        foreach (var item in pools)
        {
            CreatingPool(item.prefab, item.capacity); //Calling to create prefabs in specified capacity
        }
    }

    private void CreatingPool(GameObject prefabToClone,int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject temp = Instantiate(prefabToClone); //Instantiating the prefab
            temp.name = Constants.FRUIT_PREFAB_NAME;
            temp.SetActive(false); // Setting to inactive
            pool.Add(temp); //Adding to pool

        }
    }

    void Update()
    {
        
    }
    #endregion

    #region PUBLIC METHODS
    public GameObject Spawn(string prefabName)
    {
        foreach (GameObject item in pool)    //Searching to spawn based on prefab name
        {
            if (item.activeInHierarchy == false && prefabName==item.name) // If it is inactive, then making active and returning that object
            {
                item.SetActive(true);
                return item;
            }
           
        }
        return null;
    }
    #endregion
    #region PRIVATE METHODS

    #endregion
}
[System.Serializable]
public class ObjectToPool
{
    public GameObject prefab;
    public int capacity;
}
