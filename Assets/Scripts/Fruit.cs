using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer render;
    private PolygonCollider2D collider2D;
    private Rigidbody2D rigidbody2D;
    void OnEnable()
    {
        GameObject temp = PrefabManager.Instance.GetFruit();
        
        render.sprite = temp.GetComponent<SpriteRenderer>().sprite;
        render.sharedMaterial = temp.GetComponent<SpriteRenderer>().sharedMaterial;
        //Sprite newSprite = temp.GetComponent<SpriteRenderer>().sprite;
        //render.sprite = newSprite;

        collider2D = ((PolygonCollider2D)temp.GetComponent<PolygonCollider2D>());
        rigidbody2D.gravityScale = 0;
        //StartCoroutine("ForceApplying");
       ForceApply();
        //Debug.Log("OnEnable");

    }
    void OnDisable()
    {
        StopCoroutine("ForceApplying");
    }

    private void Awake()
    {
        render = GetComponentInChildren<SpriteRenderer>();
        collider2D = GetComponent<PolygonCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    void Start()
    {

    }
    public void ForceApply()
    {
        StartCoroutine("ForceApplying");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -8f)
            this.gameObject.SetActive(false);
    }
    

    IEnumerator ForceApplying()
    {
        
        //Debug.Log("Adding force");
        
        yield return new WaitForSeconds(2f);
        rigidbody2D.gravityScale = 1;
        rigidbody2D.AddForce(transform.up * Random.Range(25f, 40f), ForceMode2D.Impulse);


    }
   
}
