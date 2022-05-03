using UnityEngine;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField] private ItemSlot[] _slots;
    private int _activeToolIndex;

    private void Start()
    {
        foreach (var slot in _slots)
        {
            slot.SetIsActive(false);
        }

        _activeToolIndex = 0;
        _slots[_activeToolIndex].SetIsActive(true);
    }

    public void PrintItemNumber(Items item, int number)
    {
        foreach (var slot in _slots)
        {
            if(slot.Item == item)
                slot.PrintItemNumber(number);
        }
    }

    public Items ChangeActiveTool(int toolIndex)
    {
        _slots[_activeToolIndex].SetIsActive(false);
        _slots[toolIndex].SetIsActive(true);
        _activeToolIndex = toolIndex;

        return _slots[toolIndex].Item;
    }

    public bool IsThrowableActiveTool(int toolIndex)
    {
        return _slots[toolIndex].IsThrowable;
    }
}
