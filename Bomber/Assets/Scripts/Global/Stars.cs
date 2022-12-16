using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.ObjectPooled;

public class Stars : MonoBehaviour, IPooledObject
{
    [SerializeField] private float _speed;

    public TypeObjectInPool TypeObject => TypeObjectInPool.Star;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x, 90, transform.rotation.z) * Time.deltaTime * _speed);
    }
}
