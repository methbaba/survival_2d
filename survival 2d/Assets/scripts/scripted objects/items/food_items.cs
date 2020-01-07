using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new food item", menuName = "inventory system/item/food")]
public class fooditems :scripted_item
{
    public int health_restoring_power;
  
    private void Awake()
    {
        type = of_type.food;
    }

}
