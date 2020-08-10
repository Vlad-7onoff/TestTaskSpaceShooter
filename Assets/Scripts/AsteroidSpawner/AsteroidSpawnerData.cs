using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AsteroidSpawnerData", menuName = "Asteroid Spawner Data", order = 52)]
public class AsteroidSpawnerData : ScriptableObject
{
    [SerializeField] private AsteroidData[] _asteroidsTypes;
    [SerializeField] private float _spawnTime;

    public AsteroidData[] AsteroidTypes => _asteroidsTypes;
    public float SpawnTime => _spawnTime;
}
