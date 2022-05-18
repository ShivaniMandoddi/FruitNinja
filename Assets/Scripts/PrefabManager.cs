using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public GameObject[] prefabs;
    #endregion
    #region Singleton
    private static PrefabManager instance;
    public static PrefabManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new PrefabManager();
                if(instance==null)
                {
                    GameObject container = GameObject.Find("PrefabManager");
                    instance=container.GetComponent<PrefabManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetFruit()
    {
        int randomPrefab=Random.Range(0, prefabs.Length); //Returning random fruit from the list
        //Debug.Log(randomPrefab + "Random Fruit");
        return (prefabs[randomPrefab]);
    }
}
