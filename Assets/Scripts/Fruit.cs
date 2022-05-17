using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer render;
    private CircleCollider2D circlecollider2D;
    private Rigidbody2D rigidbody2D;
    void OnEnable()
    {
        GameObject temp = PrefabManager.Instance.GetFruit();
        //Debug.Log(temp.GetComponent<SpriteRenderer>().sharedMaterial);
        //Debug.Log(temp.GetComponent<SpriteRenderer>().sprite);
        //var color = temp.GetComponent<SpriteRenderer>().sharedMaterial;
        render.sprite = temp.GetComponent<SpriteRenderer>().sprite;
        render.sharedMaterial = temp.GetComponent<SpriteRenderer>().sharedMaterial;
        //Sprite newSprite = temp.GetComponent<SpriteRenderer>().sprite;
        //render.sprite = newSprite;

        circlecollider2D = ((CircleCollider2D)temp.GetComponent<CircleCollider2D>());
        rigidbody2D.gravityScale = 0;
        StartCoroutine("ForceApplying");
       // ForceApply();
        Debug.Log("OnEnable");

    }
    void OnDisable()
    {
        StopCoroutine("ForceApplying");
    }

    private void Awake()
    {
        render = GetComponentInChildren<SpriteRenderer>();
        circlecollider2D = GetComponent<CircleCollider2D>();
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
        
        Debug.Log("Adding force");
        
        yield return new WaitForSeconds(2f);
        rigidbody2D.gravityScale = 1;
        rigidbody2D.AddForce(transform.up * Random.Range(25f, 40f), ForceMode2D.Impulse);


    }
   
}
