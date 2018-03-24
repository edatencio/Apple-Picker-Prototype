using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     private Text scoreText;
     private int score;
     private Pause_Menu pauseMenu;


     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void Start()
     {
          //Find a reference to the Text-Score GameObject
          GameObject scoreGO = GameObject.Find("Text - Score");

          //Get the Text component of that GameObject
          scoreText = scoreGO.GetComponent<Text>();

          //Set the starting number of points to 0
          score = 0;
          scoreText.text = "Score: " + score.ToString();

          pauseMenu = FindObjectOfType<Pause_Menu>();

     }//void Start


     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update()
     {
          //Get the current screen position of the mouse from Input
          Vector3 mousePos2D = Input.mousePosition;

          //The Camera's Z position sets how far to push the mouse into 3D
          mousePos2D.z = Camera.main.transform.position.z;

          //Convert the point from 2D screen space into 3D game world space
          Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

          //Move the X position of this Basket to the X position of the Mouse
          Vector3 pos = gameObject.transform.position;
          pos.x = mousePos3D.x;

          if (!pauseMenu.IsPaused)
               gameObject.transform.position = pos;

     }//void Update


     /*************************************************************************************************
     *** OnCollisionEnter
     *************************************************************************************************/
     void OnCollisionEnter(Collision col)
     {
          //Find out what hit this basket
          GameObject collideWith = col.gameObject;

          if (collideWith.tag == "Apple")
          {
               Destroy(collideWith);

               //Add points for catching tha apple
               score += 100;
               scoreText.text = "Score: " + score.ToString();

               //Track the high score
               if (score > HighScore.score)
                    HighScore.score = score;

          }//if

     }//void OnCollisionEnter


}//public class Basket