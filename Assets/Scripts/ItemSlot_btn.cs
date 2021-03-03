using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot_btn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Inventory _inventory;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left click");
            _inventory.RemoveItem();
            Debug.Log(_inventory.GetItemList().Count);
        }
            

        /*else if (eventData.button == PointerEventData.InputButton.Middle)
            Debug.Log("Middle click");*/
        else if (eventData.button == PointerEventData.InputButton.Right)
            Debug.Log("Right click");
    }
}
