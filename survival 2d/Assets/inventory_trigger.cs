using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_trigger : MonoBehaviour
{
    public scriptable_inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj =collision.GetComponent<item>();
        if (obj)
        {
            inventory.add_item(obj._item, 1);
            Destroy(collision.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.inventory_list.Clear();
    }


}
