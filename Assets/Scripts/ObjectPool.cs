﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected List<GameObject> Pool { get; } = new List<GameObject>();

    protected void Init(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            Pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = Pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

}
