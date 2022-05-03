using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private GameObject _doorsFixedJoint;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetTrigger("Open");
    }

    //¬€«Œ¬ »« ¿Õ»Ã¿÷»» "Open"
    public void DestroyLock()
    {
        _doorsFixedJoint.SetActive(false);
        Destroy(gameObject);
    }
}
