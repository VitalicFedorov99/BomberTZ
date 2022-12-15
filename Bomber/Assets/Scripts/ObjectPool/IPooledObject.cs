using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bomber.ObjectPooled
{
    public interface IPooledObject
    {
        TypeObjectInPool TypeObject { get; }

        void DestroyObject();
    }
}
