using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FruitPrefabs
{
    public Sprite fruitName;
    public GameObject slicedfruitPrefab;
}

[CreateAssetMenu(fileName ="SlicingFruit",menuName ="Fruit")]
public class Slicing :ScriptableObject
{
    public FruitPrefabs[] fruit;
   
    
    public GameObject GetFruit(Sprite fruitname)
    {
        //Debug.Log(fruitname);
        for (int i = 0; i < fruit.Length; i++)
        {
            Debug.Log(fruitname);
            if (fruitname == fruit[i].fruitName)
              
                return fruit[i].slicedfruitPrefab;
            
        }
        return null;
    }
}
