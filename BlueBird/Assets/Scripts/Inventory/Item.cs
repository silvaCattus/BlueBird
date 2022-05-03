using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Items _item;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Inventory>().AddItem(_item);
            _animator.SetTrigger("Collect");
        }
    }

    private void DestoyItem()
    {
        Destroy(gameObject);
    }
}
