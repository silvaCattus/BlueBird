using System.Collections;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameStateManager _stateManager;

    public void SetStateManagerValue(GameStateManager stateManager)
    {
        _stateManager = stateManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(InvokeGameOver());
        }
    }

    private IEnumerator InvokeGameOver()
    {
        yield return new WaitForSeconds(1.2f);

        if (_stateManager != null)
            _stateManager.GameIsOver();
    }
}
