using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Items _item;
    [SerializeField] private Text _slotNumberText;
    [SerializeField] private GameObject _activeHightlightPanel;
    [SerializeField] private bool _isThrowable;

    public Items Item { get { return _item; } }
    public bool IsActive { get; private set; }
    public bool IsThrowable { get { return _isThrowable;} }

    public void SetIsActive(bool isActive)
    {
        IsActive = isActive;
        _activeHightlightPanel.SetActive(IsActive);
    }

    public void PrintItemNumber(int number)
    {
        _slotNumberText.text = number.ToString();
    }
}
