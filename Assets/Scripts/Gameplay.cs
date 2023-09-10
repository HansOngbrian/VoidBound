using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Required Features
    Spawn Enemy
    Generate the level map
    Counter for level

Editable in editor
    Room count
    Room list
*/

public class Gameplay : MonoBehaviour
{
    public Transform Spawner;
    public GameObject EnemyPrefab;

    List<Transform>_spawnerList = new List<Transform>();

    void Start()
    {
        // add all spawner into the list
        for (int i = 0; i < Spawner.childCount; i++)
        {
            _spawnerList.Add(Spawner.GetChild(i));
        }

        // summon for every spawner
        foreach (Transform _spawnpoint in _spawnerList)
        {
            Instantiate(EnemyPrefab, _spawnpoint.position, Quaternion.identity);
        }
    }

    void Update()
    {
    }
}
