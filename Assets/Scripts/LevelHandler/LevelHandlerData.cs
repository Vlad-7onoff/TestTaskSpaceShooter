using UnityEngine;

[CreateAssetMenu(fileName = "New LevelHandlerData", menuName = "Level Handler Data", order = 54)]
public class LevelHandlerData : ScriptableObject
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private AsteroidSpawnerData _asteroidSpawnerData;
    [SerializeField] private PointStorageData _pointStorageData;

    public int LevelNumber => _levelNumber;
    public AsteroidSpawnerData AsteroidSpawnerData => _asteroidSpawnerData;
    public PointStorageData PointStorageData => _pointStorageData;
}
