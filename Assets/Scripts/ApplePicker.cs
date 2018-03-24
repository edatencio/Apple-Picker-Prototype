using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ApplePicker : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public string gameScene;
     public GameObject basketPrefab;
     public int numBaskets = 3;
     public float basketBottomY = -14f;
     public float basketSpacingY = 2f;
     public List<GameObject> basketList;


     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void Start()
     {
          basketList = new List<GameObject>();

          for (int i = 0; i < numBaskets; i++)
          {
               GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
               Vector3 pos = Vector3.zero;
               pos.y = basketBottomY + (basketSpacingY * i);
               tBasketGO.transform.position = pos;
               basketList.Add(tBasketGO);

          }//for

     }//void Start


     /*************************************************************************************************
     *** Methods
     *************************************************************************************************/
     public void AppleDestroyed()
     {
          //Destroy all of the falling Apples
          GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");

          foreach (GameObject tGO in tAppleArray)
               Destroy(tGO);

          ////Destroy one of the Baskets 
          //Get the index of the last Basket in basketList
          int basketIndex = basketList.Count - 1;

          //Get a reference to that Basket GameObject
          GameObject tBasketGO = basketList[basketIndex];

          //Remove the Basket from the List and destroy the GameObject
          basketList.RemoveAt(basketIndex);
          Destroy(tBasketGO);

          //Restart the game, which doesn't affect HighScore.score
          if (basketList.Count == 0)
               SceneManager.LoadScene(gameScene);

     }//public void AppleDestroyed


}//public class ApplePicker