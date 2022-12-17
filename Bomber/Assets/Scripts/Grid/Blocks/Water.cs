using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Pathfinder;
using Bomber.ObjectPooled;

public class Water : MonoBehaviour, IPooledObject
{
    [SerializeField] private GameObject _IceBlock;
    [SerializeField] private TypeObjectOnWater _type;

    public TypeObjectInPool TypeObject => TypeObjectInPool.Water;

    public TypeObjectOnWater GetTypeObjectOnWater() 
    {
        return _type;
    }

    public void CreateIce() 
    {
            IceSwitch(true);
            _type = TypeObjectOnWater.Ice;
            GetComponent<PathNode>().SetStatePathNode(StatePathNode.Walkable);
    }

    public void DestroyIce() 
    {
        if (_type == TypeObjectOnWater.Ice)
        {
            IceSwitch(false);
            _type = TypeObjectOnWater.Nun;
            GetComponent<PathNode>().SetStatePathNode(StatePathNode.NoWalkable);
        }
    }

    private void IceSwitch(bool flag) 
    {
        _IceBlock.SetActive(flag);
    }

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}


public enum TypeObjectOnWater 
{
    Nun,
    Ice,
    Bridge
}