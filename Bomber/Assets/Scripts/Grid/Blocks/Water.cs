using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Pathfinder;


public class Water : MonoBehaviour
{
    [SerializeField] private GameObject _IceBlock;
    [SerializeField] private StateWaterBlock _state;

    public StateWaterBlock GetStateWaterBlock() 
    {
        return _state;
    }

    public void CreateIce() 
    {
            IceSwitch(true);
            _state = StateWaterBlock.Ice;
            GetComponent<PathNode>().SetStatePathNode(StatePathNode.Walkable);
    }

    public void DestroyIce() 
    {
        if (_state == StateWaterBlock.Ice)
        {
            IceSwitch(false);
            _state = StateWaterBlock.Nun;
            GetComponent<PathNode>().SetStatePathNode(StatePathNode.NoWalkable);
        }
    }

    private void IceSwitch(bool flag) 
    {
        _IceBlock.SetActive(flag);
    }
}


public enum StateWaterBlock 
{
    Nun,
    Ice,
    Bridge
}