using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new default item",menuName = "inventory system/item/default") ]
public class Default_item :scripted_item
{
    private void Awake()
    {
        type = of_type.Default;
    }



}

