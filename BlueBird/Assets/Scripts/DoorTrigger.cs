using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _lock;
    [SerializeField] private GameStateManager _gameManager;

    private GameObject _player;
    private bool _playerHasKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Inventory>().InventoryDict.TryGetValue(Items.Key, out int keyNum))
            {
                if (keyNum == 0)
                {
                    _gameManager.OpenMessagePanel("You need to find the key");
                }
                else if (keyNum > 0)
                {
                    _gameManager.OpenMessagePanel("Press \"e\"");
                    _player = other.gameObject;
                    _playerHasKey = true;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _playerHasKey && Input.GetKey(KeyCode.E))
        {
            _playerHasKey=false;
            _player.GetComponent<Inventory>().UseItem(Items.Key);
            _lock.GetComponent<DoorLock>().Open();
        }
    }
}
