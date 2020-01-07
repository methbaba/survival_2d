using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportation_m : MonoBehaviour
{
    



    private void Update()
    {
        
       if (Input.GetButtonDown("teleport"))
        {
            teleport();
           
        }

       
    }
    void teleport()
    {
        Debug.Log(SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name =="safe_area")
        {
            SceneManager.LoadSceneAsync("boss_area");
        }
        else
         if(SceneManager.GetActiveScene().name == "boss_area")
        {
            Debug.Log("you are already where you want to be ");
        }
       

      //  Debug.Log("still inside the boss area ");
       
    }
}

