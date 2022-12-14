using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : PoolObject
{
    [SerializeField] protected Player Player;
    [SerializeField] protected GameObject ObjectPrefab;
    [SerializeField] protected float MinSecondsBetweenSpawn;
    [SerializeField] protected float MaxSecondsBetweenSpawn;
    [SerializeField] protected bool IsSpawningOnTimer;

    protected float _secondsBetweenSpawn;
    protected float _elapsedTime;

    protected virtual void Start()
    {
        if (IsSpawningOnTimer)
            _secondsBetweenSpawn = Random.Range(MinSecondsBetweenSpawn, MaxSecondsBetweenSpawn);

        Initialize(ObjectPrefab);
    }

    protected virtual void Update()
    {
        if (IsSpawningOnTimer == false)
            return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject obj))
            {
                Spawn(obj);
            }
        }
    }

    protected virtual void Spawn(GameObject obj)
    {
        _elapsedTime = 0;
        _secondsBetweenSpawn = Random.Range(MinSecondsBetweenSpawn, MaxSecondsBetweenSpawn);
        Setup(obj, new Vector2(transform.position.x, Randomizer.RandomPositionY()));
    }

    protected virtual void Setup(GameObject obj, Vector2 position)
    {
        obj.SetActive(true);
        obj.transform.position = position;
    }

}
