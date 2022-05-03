using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryGUI _inventoryGUI;
    public Dictionary<Items, int> InventoryDict { get; private set; }
    private int _activeToolIndex;
    private int _allToolNumber;
    public Items _activeToolName { get; private set; }
    public bool ActiveToolIsThrowable { get; private set; }

    private void Start()
    {
        InventoryDict = new Dictionary<Items, int>();

        var arrayItems = (Items[])Enum.GetValues(typeof(Items));

        for (int i = 0; i < arrayItems.Length; i++)
        {
            InventoryDict.Add(arrayItems[i], 0);
        }

        _allToolNumber = arrayItems.Length;
        _activeToolIndex = 0;
        AddItem(Items.Apple);
        AddItem(Items.Apple);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            ChangeActiveTool();
    }

    public void AddItem(Items item)
    {
        if (InventoryDict.ContainsKey(item))
        {
            InventoryDict[item]++;
            _inventoryGUI.PrintItemNumber(item, InventoryDict[item]);
        }
    }

    public void ChangeActiveTool()
    {
        if (_activeToolIndex + 1 <= _allToolNumber - 1)
            _activeToolIndex++;
        else
            _activeToolIndex = 0;

        _activeToolName = _inventoryGUI.ChangeActiveTool(_activeToolIndex);
        ActiveToolIsThrowable = _inventoryGUI.IsThrowableActiveTool(_activeToolIndex);
    }

    public void UseItem(Items item)
    {
        if (InventoryDict.ContainsKey(item) && InventoryDict[item] > 0)
        {
            InventoryDict[item]--;
            _inventoryGUI.PrintItemNumber(item, InventoryDict[item]);
        }
    }
}
