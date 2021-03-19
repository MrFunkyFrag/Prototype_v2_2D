using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Items> _itemsList;    
    [SerializeField] private ItemsDatabase _itemsDatabase;
    [SerializeField] private UI_Inventory _uiInventory;

    public bool canDestroyItem = false;

    private int _inventorySpace = 9; // Later on it will be matched to the type of backpack
    private int _maxCarryingCapacity = 10; // Later on it will be matched to the STR
    [SerializeField] private int _currentCarryingCapacity = 0;

    public bool isInventorySpaceFull = false;
    public bool isCarryingCapacityFull = false;
    
    void Awake()
    {
        _itemsList = new List<Items>();
    }
    

    public void AddItem(Items item)
    {
        bool itemAlreadyInInventory = false;

        foreach (Items inventoryItems in _itemsList)
        {
            if (inventoryItems.itemID == item.itemID && _currentCarryingCapacity < _maxCarryingCapacity)
            {
                inventoryItems.amount++;
                itemAlreadyInInventory = true;
                canDestroyItem = true;
                _currentCarryingCapacity++;
            }
        }

        if (!itemAlreadyInInventory && _itemsList.Count < _inventorySpace && _currentCarryingCapacity < _maxCarryingCapacity)
        {
            _itemsList.Add(item);
            item.amount++;
            canDestroyItem = true;
            _currentCarryingCapacity++;
        }

        if (_itemsList.Count >= _inventorySpace)
            isInventorySpaceFull = true;
        else
            isInventorySpaceFull = false;


        if (_currentCarryingCapacity >= _maxCarryingCapacity)
            isCarryingCapacityFull = true;
        else
            isCarryingCapacityFull = false;
        
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
                _currentCarryingCapacity--;
                itemInInventory = inventoryItems;
            }
        }
        if (itemInInventory != null && itemInInventory.amount <= 0)
        {
            _itemsList.Remove(itemInInventory);
        }

        if (_itemsList.Count >= _inventorySpace)
            isInventorySpaceFull = true;
        else
            isInventorySpaceFull = false;


        if (_currentCarryingCapacity >= _maxCarryingCapacity)
            isCarryingCapacityFull = true;
        else
            isCarryingCapacityFull = false;

        _uiInventory.RefreshInventoryItems();
    }

    public List<Items> GetItemList()
    {
        return _itemsList;
    }    

}
