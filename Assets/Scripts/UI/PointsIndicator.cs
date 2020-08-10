using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentPointsIndicator;
    [SerializeField] private TMP_Text _pointsToWinIndicator;

    public void FillIndicators(int currentPoints, int pointsToWin)
    {
        _currentPointsIndicator.text = currentPoints.ToString();
        _pointsToWinIndicator.text = pointsToWin.ToString();
    }

    public void SetCurrentPoints(int points)
    {
        _currentPointsIndicator.text = points.ToString();
    }
}
