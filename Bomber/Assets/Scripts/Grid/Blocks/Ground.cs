using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Pathfinder;
using Bomber.ObjectPooled;

public class Ground : MonoBehaviour, IPooledObject
{
    [SerializeField] private TypeObjectOnGround _typeObjecOnGround;

    public TypeObjectInPool TypeObject => TypeObjectInPool.Ground;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }

    public TypeObjectOnGround GetTypeObjectOnGround() 
    {
        return _typeObjecOnGround;
    }
}





public enum TypeObjectOnGround 
{
    Nun,
    WoodenWall,
    MetalWall,
    SpawnerEnemy,
    Star,
    Exit,
}
