using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bomber.ObjectPooled
{
    public class PooledObject : MonoBehaviour
    {
        public TypeObjectInPool TypeObject;

        public void DestroyObject() 
        {
            ObjectPool.instance.DestroyObject(gameObject);
        }
    }
}
