using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum of_type { 

    food,
    weapon,
    armor,
    potion,

    Default

}


public abstract class scripted_item : ScriptableObject
{
    [Tooltip(" input the gameobject to spwan in the UI of the player inventory ")]
    public GameObject prefab;
    public of_type type;
  
    [TextArea(10,10)]
    public string decription;


}

