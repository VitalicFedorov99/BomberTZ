using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Bomber.ObjectPooled;
public class SpawnerEnemy : MonoBehaviour, IPooledObject
{
    public TypeObjectInPool TypeObject => TypeObjectInPool.EnemySpawn;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}
