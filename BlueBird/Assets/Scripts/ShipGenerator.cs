using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGenerator : MonoBehaviour
{
    [SerializeField] private Transform _gateTransform;
    [SerializeField] private GameObject _shipPrefab;
    [SerializeField] private GameStateManager _stateManager;

    private GameObject _ship;

    private void Start()
    {
        Invoke(nameof(GenerateShip), 0.5f);
    }

    private void GenerateShip()
    {
        if (Random.Range(0, 2) == 0)
        {
            _ship = GameObject.Instantiate(_shipPrefab);
            _ship.transform.position = transform.position;
            _ship.transform.LookAt(new Vector3(_gateTransform.position.x, transform.position.y, _gateTransform.position.z));
            _ship.GetComponent<GameOverTrigger>().SetStateManagerValue(_stateManager);
        }

        Invoke(nameof(GenerateShip), 0.8f);
    }
}
