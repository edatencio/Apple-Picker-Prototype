using UnityEngine;


public class Apple : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public static float bottomY = -20f;


     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update()
     {
          if (gameObject.transform.position.y < bottomY)
          {
               //Get a reference to the ApplePicker component of Main Camera
               ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

               //Call the public AppleDestroyed() method of apScript
               apScript.AppleDestroyed();

               Destroy(gameObject);

          }//if

     }//void Update


}//public class Apple