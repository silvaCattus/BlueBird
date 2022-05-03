using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameStateManager _gameStateManager;
    public event Action Finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Finished!=null)
                Finished();

            _gameStateManager.LevelIsCompleted();
        }
    }
}
