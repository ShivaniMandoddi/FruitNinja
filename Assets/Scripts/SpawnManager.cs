using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region PRIVATE VARIABLES
   
    
    #endregion
    void Start()
    {
        StartCoroutine("SpawnFruits"); //Spawning fruits
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return (new WaitForSeconds(Random.Range(0.5f,1.5f))); //At random intervals spawning the fruits
            SpawningFruits();
        }
    }
    public void SpawningFruits()
    {
        GameObject fruit = PoolManager.Instance.Spawn(Constants.FRUIT_PREFAB_NAME); // Spawning fruit from pool
        Vector2 screenresolution = new Vector2(Screen.width, Screen.height); // Taking screen width and height as a vector
        Vector2 worldScreenResolution=Camera.main.ScreenToWorldPoint(screenresolution); // Changing to world coordinates
        
        fruit.transform.position = new Vector2(Random.Range(-worldScreenResolution.x, worldScreenResolution.x), -worldScreenResolution.y - 1); // Random position is assigned to fruit based on screen resolution
       
        
        
    }
}
