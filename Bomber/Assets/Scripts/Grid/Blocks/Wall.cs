using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.ObjectPooled;

public class Wall : MonoBehaviour, IPooledObject
{
    public TypeObjectInPool TypeObject => TypeObjectInPool.WoodWall;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }

  
}
