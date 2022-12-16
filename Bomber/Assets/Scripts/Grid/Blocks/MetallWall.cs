using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.ObjectPooled;

public class MetallWall : MonoBehaviour, IPooledObject
{
    public TypeObjectInPool TypeObject => TypeObjectInPool.MetalWall;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}
