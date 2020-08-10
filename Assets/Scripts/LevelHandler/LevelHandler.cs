using UnityEngine;
using IJunior.TypedScenes;

public class LevelHandler : MonoBehaviour, ISceneLoadHandler<LevelHandlerData>
{
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private PointStorage _pointStorage;

    public int LevelNumber { get; private set; }
    public LevelHandlerData LevelHandlerData { get; private set; }

    public void OnSceneLoaded(LevelHandlerData levelHandlerData)
    {
        LevelHandlerData = levelHandlerData;
        Init();
    }

    private void Init()
    {
        _asteroidSpawner.Init(LevelHandlerData.AsteroidSpawnerData);
        _pointStorage.Init(LevelHandlerData.PointStorageData);
        LevelNumber = LevelHandlerData.LevelNumber;
        Time.timeScale = 1;
    }
}
