using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public GameObject prefabToClone;
    public int capacity;
    #endregion
    #region PRIVATE VARIABLES
    List<GameObject> pool=new List<GameObject>();
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
        for (int i = 0; i < capacity; i++)
        {
            GameObject temp = Instantiate(prefabToClone);
            temp.SetActive(false);
            pool.Add(temp);

        }
    }

   
    void Update()
    {
        
    }
    #endregion

    #region PUBLIC METHODS
    public GameObject Spawn()
    {
        foreach (GameObject item in pool)
        {
            if (item.activeInHierarchy == false)
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
