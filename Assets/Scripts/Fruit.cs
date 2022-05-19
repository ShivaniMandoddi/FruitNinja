using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    #region PUBLIC VARIABLES
    
    #endregion
    // Start is called before the first frame update
    #region PRIVATE VARIABLES
    private SpriteRenderer render;
    private PolygonCollider2D collider2D;
    private Rigidbody2D rigidbody2D;
   
    #endregion

    #region MONOBEHAVIOUR METHODS

    
    private void Awake() //Acessing all components
    {
        render = GetComponentInChildren<SpriteRenderer>();
        collider2D = GetComponent<PolygonCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    void OnEnable()
    {
        GameObject temp = PrefabManager.Instance.GetFruit();    //Getting random fruit prefab from prefab manager
        //Transform slicedfruit = temp.transform.GetChild(0).gameObject.transform;
        
        render.sprite = temp.GetComponent<SpriteRenderer>().sprite;   // Applying random fruit's sprite and collider to current object
        render.sharedMaterial = temp.GetComponent<SpriteRenderer>().sharedMaterial;
        

        //Sprite newSprite = temp.GetComponent<SpriteRenderer>().sprite;
        //render.sprite = newSprite;

        collider2D = ((PolygonCollider2D)temp.GetComponent<PolygonCollider2D>());
        rigidbody2D.gravityScale = 0; //Initially gravity making to zero
        
       ForceApply(); // Calling to apply force to fruit
        //Debug.Log("OnEnable");

    }
    void OnDisable()
    {
        StopCoroutine("ForceApplying");
    }

    
    void Start()
    {

    }
    void Update()
    {
        if (transform.position.y < -8f)
            this.gameObject.SetActive(false);
    }


    IEnumerator ForceApplying()
    {

        //Debug.Log("Adding force");

        yield return new WaitForSeconds(1f);
        rigidbody2D.gravityScale = 1;
        rigidbody2D.AddForce(transform.up * Random.Range(25f, 40f), ForceMode2D.Impulse); //Applying instant force in upward direction


    }
    #endregion

    #region PUBLIC METHODS
    public void ForceApply()
    {
        StartCoroutine("ForceApplying"); 
    }
    #endregion


    // Update is called once per frame


}
