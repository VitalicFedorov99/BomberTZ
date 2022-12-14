using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    TypeObjectInPool TypeObject { get; }

    void DestroyObject();
}
