using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Bomber.ObjectPooled;
public class Exit : MonoBehaviour, IPooledObject
{
    public TypeObjectInPool TypeObject => TypeObjectInPool.Exit;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}
