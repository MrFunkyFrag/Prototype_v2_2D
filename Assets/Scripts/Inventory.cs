using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Items> _itemsList;

    // Start is called before the first frame update
    void Start()
    {
        _itemsList = new List<Items>();

        Debug.Log("Invetory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
