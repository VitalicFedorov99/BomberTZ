using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
public class PathFinder : MonoBehaviour
{
    [SerializeField] private List<PathNode> _toSearch;
    [SerializeField] private List<PathNode> _processed;
    [SerializeField] private List<PathNode> _result;

    [SerializeField] private PathNode _start;
    [SerializeField] private PathNode _end;
    [SerializeField] private Enemy _enemy;


    public List<PathNode> FindPath(PathNode startPoint, PathNode endPoint, out List<PathNode> listResult, Enemy enemy)
    {
        _enemy = enemy;
        _toSearch = new List<PathNode> { startPoint };
        _processed = new List<PathNode>();
        _result = new List<PathNode>();
        listResult = new List<PathNode>();
        int count = 0;
        var currentHex = _toSearch[0];
        while (currentHex != endPoint)
        {
            currentHex = _toSearch[0];
            
            foreach (var t in _toSearch)
            {
                bool flag1 = Vector3.Distance(new Vector3(currentHex.transform.position.x, 0, currentHex.transform.position.z), new Vector3(endPoint.transform.position.x, 0, endPoint.transform.position.z))
                    > Vector3.Distance(new Vector3(t.transform.position.x, 0, t.transform.position.z), new Vector3(endPoint.transform.position.x, 0, endPoint.transform.position.z));
                if (flag1)
                {
                    currentHex = t;
                }
            }

            _processed.Add(currentHex);
            _toSearch.Remove(currentHex);

            foreach (var neighbor in currentHex.GetNeighbours().Where(t => t.GetStatePathNode() == StatePathNode.Walkable && !_processed.Contains(t)))
            {
                var inSearch = _toSearch.Contains(neighbor);

                var costToNeighbor = Vector3.Distance(new Vector3(neighbor.transform.position.x, 0, neighbor.transform.position.z),
                    new Vector3(endPoint.transform.position.x, 0, endPoint.transform.position.z));

                var cost = Vector3.Distance(new Vector3(currentHex.transform.position.x, 0, currentHex.transform.position.z),
                    new Vector3(endPoint.transform.position.x, 0, endPoint.transform.position.z));

                if (!inSearch || costToNeighbor < cost)
                {
                    _toSearch.Add(neighbor);
                    count = 0;
                }
            }
            count++;
            if(count >= 5) 
            {
                break;
            }
        }
        //foreach (var node in _result)
          //  if (_processed[_processed.Count - 1] != _end)
           // {
            //    _processed = new List<PathNode>();
           // }
        foreach (var node in _processed) 
        {
            listResult.Add(node);
        }
            return _processed;
    }

    public void TestPathFinder()
    {
       // FindPath(_start, _end);
    }
}