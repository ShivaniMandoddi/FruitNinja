using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionwithFruit : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public GameObject sparkeffect;
    public Text scoreText;
    public Text timeText;
    public float maxTime = 30f;
    #endregion

    #region PRIVATE VARIABLES

    private float startTime;
    private int score;
    #endregion
    #region MONOBEHAVIOUR METHODS


    void Start()
    {
        startTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        int time = (int)startTime;
        timeText.text = time.ToString();
       
        if(startTime>maxTime)        //If it reaches max time , the game starts again
        {
            Debug.Log(startTime);
            startTime = 0f;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

           
        }
    }
    private void OnEnable()
    {
        UserHandler.UserInputHandler.OnPanStartAction += DetectCollision; //Adding an event
    }
    private void OnDisable()
    {
        UserHandler.UserInputHandler.OnPanStartAction -= DetectCollision; // Desubscribing the event, when gameobject is inactive
    }
    #endregion
    #region PUBLIC METHODS
    public void DetectCollision(Touch touch)
    {
        Vector3 worldtouchPosition = Camera.main.ScreenToWorldPoint(touch.position); // Changing pixelcoordinates to world coordinates
        RaycastHit2D hitinfo = Physics2D.Raycast(worldtouchPosition, Vector3.forward); // Passing a ray from touch position
        if (hitinfo.collider != null && hitinfo.collider.gameObject.layer == Constants.FRUIT_LAYER_NUMBER) // If it hits the fruit collider, then increasing the score
        {
            // Debug.Log("Fruit is collided");
            Destroy(Instantiate(sparkeffect, hitinfo.collider.gameObject.transform.position, Quaternion.identity), 1f);
            score++;
            scoreText.text = "Score: "+score.ToString();
            hitinfo.collider.gameObject.SetActive(false); //Returning Back to Pool
        }


    }
    #endregion

}
