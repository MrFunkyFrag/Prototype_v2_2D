using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Items> _itemsList;
    private Items _item;
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

        FunctionalityTest();
    }
    

    public void AddItem(Items item)
    {
        _itemsList.Add(item);
    }

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
        AddItem(_item);
        AddItem(_item);
        Debug.Log(_itemsList[0].itemName);
    }

}
