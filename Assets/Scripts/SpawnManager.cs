using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region PRIVATE VARIABLES
    private SpriteRenderer render;
    private CircleCollider2D circleCollider;
    
    #endregion
    void Start()
    {
        StartCoroutine("SpawnFruits");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return (new WaitForSeconds(3f));
            SpawningFruits();
        }
    }
    public void SpawningFruits()
    {
        GameObject fruit = PoolManager.Instance.Spawn();
        Vector2 screenresolution = new Vector2(Screen.width, Screen.height);
        Vector2 worldScreenResolution=Camera.main.ScreenToWorldPoint(screenresolution);
        
        fruit.transform.position = new Vector2(Random.Range(-worldScreenResolution.x, worldScreenResolution.x), -worldScreenResolution.y - 1);
       
        
        
    }
}
