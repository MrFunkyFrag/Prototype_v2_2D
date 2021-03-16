using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Items> _itemsList;    
    [SerializeField] private ItemsDatabase _itemsDatabase;
    [SerializeField] private UI_Inventory _uiInventory;

    
    void Awake()
    {
        _itemsList = new List<Items>();
    }
    

    public void AddItem(Items item)
    {
        bool itemAlreadyInInventory = false;
        foreach (Items inventoryItems in _itemsList)
        {            
            if (inventoryItems.itemID == item.itemID)
            {
                inventoryItems.amount++;
                itemAlreadyInInventory = true;
            }
        }
        if (!itemAlreadyInInventory)
        {
            _itemsList.Add(item);
        }

        _uiInventory.RefreshInventoryItems();
        
    }        


    public void RemoveItem(Items item)
    {
        Items itemInInventory = null;
        foreach (Items inventoryItems in _itemsList)
        {
            if (inventoryItems.itemID == item.itemID)
            {
                inventoryItems.amount--;
                itemInInventory = inventoryItems;
            }
        }
        if (itemInInventory != null && itemInInventory.amount <= 0)
        {
            _itemsList.Remove(itemInInventory);
        }

        _uiInventory.RefreshInventoryItems();
    }

    public List<Items> GetItemList()
    {
        return _itemsList;
    }    

}
