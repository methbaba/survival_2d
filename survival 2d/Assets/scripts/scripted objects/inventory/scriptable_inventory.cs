using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="new custom_inventory",menuName ="inventory system/inventory")]
public class scriptable_inventory : ScriptableObject
{
    public List<inventory_slot> inventory_list = new List<inventory_slot>();

    public void add_item( scripted_item _item , int amount)
    {
        bool has_item = false;
        for (int i = 0; i < inventory_list.Count; i++)
        {
            if (inventory_list[i].item == _item)
            {
                inventory_list[i].add_amount(amount);
                has_item = true;
            }
        }
        if (!has_item)
        {
            inventory_list.Add(new inventory_slot(_item, amount));
           
        }
    }

}


[System.Serializable]
public class inventory_slot
{
    public scripted_item item;
    public int amount_of_items;

    public  inventory_slot  (scripted_item _item , int _amount_of_items)
    {
        this.item = _item;
        this.amount_of_items = _amount_of_items;

        
    }

    public void add_amount(int value)
    {
        amount_of_items += value;
    }

}
