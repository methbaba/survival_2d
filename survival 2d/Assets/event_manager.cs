using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_manager : MonoBehaviour
{
   private static event_manager _instance;

    public static event_manager Event_M
    {
        get
        {
            GameObject E_M = new GameObject("Event manager");
            E_M.AddComponent<event_manager>();

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }


    // declaring some properties for the child classes to refer to



}
