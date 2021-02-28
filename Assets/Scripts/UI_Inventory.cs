using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private Image[] _itemImages;
    [SerializeField]
    private Text[] _itemAmount;

    private void Awake()
    {

        foreach (Image image in _itemImages)
        {
            image.GetComponent<Image>();
            image.enabled = false;
        }

        foreach (Text text in _itemAmount)
        {
            text.GetComponent<Text>();
        }
    }

    /*public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
    }*/

    public void RefreshInventoryItems()
    {
        for (int i = 0; i < _inventory.GetItemList().Count; i++)
        {
            if (_itemImages[i].sprite == null) // prevents substituting image if slot is already taken
            {
                _itemImages[i].enabled = true;
                _itemImages[i].sprite = _inventory.GetItemList()[i].itemSprite;
                _itemAmount[i].text = _inventory.GetItemList()[i].amount.ToString();
            }
            else if (_itemImages[i].sprite == _inventory.GetItemList()[i].itemSprite) // if it's the same item - update its amount? NOT TESTED
            {
                _itemAmount[i].text = _inventory.GetItemList()[i].amount.ToString();
            }
            
        } 
        
    }
 
}
