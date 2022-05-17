using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionwithFruit : MonoBehaviour
{
   
    void Start()
    {
        UserHandler.UserInputHandler.OnPanStartAction += DetectCollision;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        UserHandler.UserInputHandler.OnPanStartAction += DetectCollision;
    }
    private void OnDisable()
    {
        UserHandler.UserInputHandler.OnPanStartAction -= DetectCollision;
    }
    public void DetectCollision(Touch touch)
    {
        Vector3 worldtouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D hitinfo = Physics2D.Raycast(worldtouchPosition, Vector3.forward);
        if(hitinfo.collider!=null && hitinfo.collider.gameObject.layer==6)
        {
            Debug.Log("Fruit is collided");
            //Destroy(hitinfo.collider.gameObject, 2f);
          
            hitinfo.collider.gameObject.SetActive(false);
        }
        
        
    }
}
