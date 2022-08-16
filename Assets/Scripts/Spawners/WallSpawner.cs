using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : Spawner
{
    protected override void Spawn(GameObject obj)
    {
        _elapsedTime = 0;
        _secondsBetweenSpawn = Random.Range(MinSecondsBetweenSpawn, MaxSecondsBetweenSpawn);
        Setup(obj, new Vector2(transform.position.x, transform.position.y));
    }
}
