using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PointStorage", menuName = "Point Storage Data", order = 53)]
public class PointStorageData : ScriptableObject
{
    [SerializeField] private int _pointsToWin;

    public int PointsToWin => _pointsToWin;
}
