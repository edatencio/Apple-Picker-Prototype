using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    static public int score = 1000;


    /*************************************************************************************************
    *** Awake
    *************************************************************************************************/
    void Awake()
    {
	   //If the ApplePickerHighScore already exists, read it
	   if (PlayerPrefs.HasKey("ApplePickerHighScore"))
		  score = PlayerPrefs.GetInt("ApplePickerHighScore");

	   //Assign the high score to ApplePickerHighScore
	   PlayerPrefs.SetInt("ApplePickerHighScore", score);

    }//void Awake


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
        
    
    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   Text text = gameObject.GetComponent<Text>();
	   text.text = "High Score: " + score.ToString();

	   //Update ApplePickerHighScore
	   if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
		  PlayerPrefs.SetInt("ApplePickerHighScore", score);

    }//void Update


}//public class HighScore