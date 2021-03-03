using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Items> _itemsList;
    private Items _item;
    private Items _item2;
    [SerializeField]
    private ItemsDatabase _itemsDatabase;

    [SerializeField]
    private UI_Inventory _uiInventory;
    //private Inventory _inventory;

    
    void Awake()
    {
        _itemsList = new List<Items>();
        /*_inventory = new Inventory();        
        _uiInventory.SetInventory(_inventory);*/

        //FunctionalityTest();
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

    public void RemoveItem()
    {
        if (_itemsList.Count > 0)
        {
            if (_itemsList[0].amount >= 2 && _itemsList[0].itemSprite == _uiInventory.GetItemImageList()[0].sprite)
            {
                _itemsList[0].amount--;

            }
            else if (_itemsList[0].amount <= 1 && _itemsList[0].itemSprite == _uiInventory.GetItemImageList()[0].sprite)
            {
                _itemsList.RemoveAt(0);
            }
        }

        if (_itemsList.Count == 0)
        {
            _uiInventory.RemoveLastUIItem();
        }

        _uiInventory.RefreshInventoryItems();

    }

    /*public void RemoveItem(Items item)
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
    }*/

    public List<Items> GetItemList()
    {
        return _itemsList;
    }


    /// <summary>
    /// TEST: Adding a random item from database to the list, then checking if it was added properly and what item it was.
    /// </summary>
    private void FunctionalityTest()
    {
        _item = _itemsDatabase.items[Random.Range(0, _itemsDatabase.items.Length)];
        _item2 = _itemsDatabase.items[Random.Range(0, _itemsDatabase.items.Length)];
        AddItem(_item);
        AddItem(_item2);
        Debug.Log(_itemsList[0].itemName);
        Debug.Log(_itemsList[0].amount);
    }

}
