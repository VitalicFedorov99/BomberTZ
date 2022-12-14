using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bomber.Pathfinder
{
    public class PathNode : MonoBehaviour
    {
        [SerializeField] private StatePathNode _state;
        [SerializeField] private List<PathNode> _neighbours = new List<PathNode>();

        public StatePathNode GetStatePathNode()
        {
            return _state;
        }

        public void AddNeighbour(PathNode neighbour)
        {
            _neighbours.Add(neighbour);
        }

        public void SetStatePathNode(StatePathNode state)
        {
            _state = state;
        }

        public List<PathNode> GetNeighbours()
        {
            return _neighbours;
        }

        public void ClearNeighbours() 
        {
            _neighbours.Clear();
        }
    }


    public enum StatePathNode
    {
        Walkable,
        NoWalkable
    }
}
