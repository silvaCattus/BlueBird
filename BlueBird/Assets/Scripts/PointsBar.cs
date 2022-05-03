using System;
using UnityEngine;

public class PointsBar : MonoBehaviour
{
    [SerializeField] private GameObject _pointBarCursor;
    [SerializeField] private GameObject _upperPoint;
    [SerializeField] private GameObject _bottomPoint;
    [SerializeField] private int _points;

    private Vector2[] _pointPositions;
    private int _currentIndexPointPos;
    private float _step;

    public event Action PointGetMax;

    private void Start()
    {
        _currentIndexPointPos = 0;
        _pointPositions = new Vector2[_points];
        _pointPositions[0] = _bottomPoint.transform.position;
        _pointPositions[_pointPositions.Length-1] = _upperPoint.transform.position;

        float barHeight = Vector2.Distance(_upperPoint.transform.position, _bottomPoint.transform.position);
        _step = barHeight / _pointPositions.Length-2;

        for (int i = 1; i < _pointPositions.Length-1; i++)
        {
            _pointPositions[i] = new Vector2(_upperPoint.transform.position.x, _bottomPoint.transform.position.y + _step * i);
        }
    }

    public void MoveBarCursor(bool forward = true)
    {
        if (forward)
            _currentIndexPointPos++;
        else
            _currentIndexPointPos--;

        Debug.Log(_pointPositions);
        Debug.Log(_pointBarCursor==null);

        _pointBarCursor.transform.position = _pointPositions[_currentIndexPointPos];

        if (_currentIndexPointPos == _points - 1 && PointGetMax!=null)
            PointGetMax();
    }
}
