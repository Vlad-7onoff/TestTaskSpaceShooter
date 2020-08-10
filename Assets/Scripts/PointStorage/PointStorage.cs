using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointStorage : MonoBehaviour
{
    [SerializeField] private PointsIndicator _pointsIndicator;

    private int _pointsToWin;
    private int _points;

    public UnityAction Collected;

    public void Init(PointStorageData pointStorageData)
    {
        _pointsToWin = pointStorageData.PointsToWin;
        _pointsIndicator.FillIndicators(_points, _pointsToWin);
    }

    public void AddPoint(int reward)
    {
        _points += reward;
        _pointsIndicator.SetCurrentPoints(_points);
        if (_points >= _pointsToWin)
            Collected?.Invoke();
    }
}
