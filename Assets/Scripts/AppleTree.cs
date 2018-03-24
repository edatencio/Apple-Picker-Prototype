using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AppleTree : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves in meters/seconds
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at wich Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;
	
	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   //Dropping apples every seconds   
	   InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    
    }//void Start
    
    
    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   //Basic movement
	   Vector3 pos = gameObject.transform.position;
	   pos.x += speed * Time.deltaTime;
	   gameObject.transform.position = pos;

	   //Changing direction
	   if (pos.x < -leftAndRightEdge)
		  speed = Mathf.Abs(speed);
	   else if (pos.x > leftAndRightEdge)
		  speed = -Mathf.Abs(speed);

    }//void Update


    /*************************************************************************************************
    *** LateUpdate
    *************************************************************************************************/
    void LateUpdate ()
    {
	   //Changing direction randomly
	   if (Random.value < chanceToChangeDirections)
		  speed *= -1;

    }//void LateUpdate


    /*************************************************************************************************
    *** Methods
    *************************************************************************************************/
    void DropApple()
    {
	   GameObject apple = Instantiate(applePrefab) as GameObject;
	   apple.transform.position = gameObject.transform.transform.position;

    }//DropApple


}//public class AppleTree