using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Bomber.ObjectPooled;
public class Bridge : MonoBehaviour, IPooledObject
{
    public TypeObjectInPool TypeObject => TypeObjectInPool.Bridge;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}
