using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public Items[] items;

    private void Start()
    {
        foreach (var item in items)
        {
            item.amount = 0;
        }
    }
}
