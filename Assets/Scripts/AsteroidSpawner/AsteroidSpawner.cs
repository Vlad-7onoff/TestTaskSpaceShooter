using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : ObjectPool
{
    [SerializeField] private LevelBoundary _levelBoundary;
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private PointStorage _pointStorage;
    [SerializeField] private Transform _heightSpawnPoint;
    [SerializeField] private float _indentDownBoundaty;
    [SerializeField] private AsteroidData[] _asteroidTypes;

    private float _downBoundary;
    private float _spawnTime;
    private float _elapsedTime;

    private void Start()
    {
        _downBoundary = _levelBoundary.LeftDownCorner.y - _indentDownBoundaty;
        Init(_asteroidPrefab);
        Subscribes();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnTime)
        {
            if (TryGetObject(out GameObject asteroid))
            {
                _elapsedTime = 0;

                float widthtSpawnPoint = Random.Range(_levelBoundary.LeftDownCorner.x, _levelBoundary.RightUpCorner.x);
                Vector3 spawnPoint = new Vector3(widthtSpawnPoint, _heightSpawnPoint.position.y, 0);
                int asteroidType = Random.Range(0, _asteroidTypes.Length);
                SetAsteroid(asteroid, _asteroidTypes[asteroidType], spawnPoint);
            }
        }
    }

    public void Init(AsteroidSpawnerData asteroidSpawnerData)
    {
        _asteroidTypes = asteroidSpawnerData.AsteroidTypes;
        _spawnTime = asteroidSpawnerData.SpawnTime;
    }

    private void SetAsteroid(GameObject prefab, AsteroidData asteroidData, Vector3 SpawnPoint)
    {
        prefab.SetActive(true);
        Asteroid asteroid = prefab.GetComponent<Asteroid>();
        asteroid.Fill(asteroidData);
        prefab.transform.position = SpawnPoint;
    }

    private void Subscribes()
    {
        foreach (GameObject gameObject in Pool)
        {
            Asteroid asteroid = gameObject.GetComponent<Asteroid>();
            asteroid.ShotDown += _pointStorage.AddPoint;
        }
    }
}
