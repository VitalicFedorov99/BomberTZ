using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


using Bomber.Pathfinder;
using Bomber.PlayerSystem;


namespace Bomber.Enemies
{
    public class MoveEnemy : MonoBehaviour
    {


        [SerializeField] private float _speed;
        [SerializeField] private LocatePosition _playerPosition;
        [SerializeField] private List<PathNode> _wayPoints;
        [SerializeField] private float _timeIntervalSearchWay;
        
        private PathFinder _pathFinder;
        private LocatePosition _locatePosition;
        private int _counterWay;
        private PathNode _playerNode;

        private IEnumerator _coroutineMove;
        private IEnumerator _coroutineThink;

        public void Setup(Player player)
        {
            _playerPosition = player.GetComponent<LocatePosition>();
            _pathFinder = GetComponent<PathFinder>();
            _locatePosition = GetComponent<LocatePosition>();
            Move();
        }

        public void MoveStop()
        {
            StopAllCoroutines();
        }

        public void Move()
        {
            _coroutineThink = ÑoroutineSearchEnemy();
            StartCoroutine(_coroutineThink);
        }





        private IEnumerator CoroutineMove(List<PathNode> wayPoints)
        {
            if (wayPoints.Count > 0)
            {
                _counterWay = wayPoints.Count;
                int i = 0;
                var currentPoint = wayPoints[i];

                while (Vector3.Distance(transform.position, wayPoints[_counterWay - 1].transform.position) > 0.2f)
                {
                    Vector3 currentPos = new Vector3(currentPoint.transform.position.x, transform.position.y, currentPoint.transform.position.z);
                    transform.position =
                        Vector3.MoveTowards(transform.position, currentPos, _speed * Time.deltaTime);
                    transform.LookAt(currentPos);
                    if ((Vector3.Distance(transform.position, currentPos) < 0.1f && i < _counterWay))
                    {
                        i++;
                        currentPoint = wayPoints[i];
                    }
                    yield return null;
                }
            }
        }

        private IEnumerator CoroutineWander(PathNode node)
        {
            var neighbours = node.GetNeighbours();
            int rand = Random.Range(0, neighbours.Count);
            while (neighbours[rand].GetStatePathNode() == StatePathNode.NoWalkable)
            {
                rand = Random.Range(0, neighbours.Count);
            }
            var neighnour = neighbours[rand];
            while (Vector3.Distance(transform.position, neighnour.transform.position) > 0.5f)
            {
                Vector3 currentPos = new Vector3(neighnour.transform.position.x, transform.position.y, neighnour.transform.position.z);
                transform.position =
                    Vector3.MoveTowards(transform.position, currentPos, _speed * Time.deltaTime);
                transform.LookAt(currentPos);
                yield return null;
            }
            _coroutineMove = CoroutineWander(neighnour);
            StartCoroutine(_coroutineMove);
        }

        private IEnumerator ÑoroutineSearchEnemy()
        {
            _wayPoints.Clear();
            var place = _locatePosition.SearchPlace();
            _playerPosition.SearchPlace();
            var placePlayer = _playerPosition.GetPlace();
            _playerNode = placePlayer.GetComponent<PathNode>();
            _pathFinder.FindPath(place.GetComponent<PathNode>(), placePlayer.GetComponent<PathNode>(), out _wayPoints);
            if (Vector3.Distance(_wayPoints.Last().transform.position, placePlayer.transform.position) > 0.5f)
            {
                _coroutineMove = CoroutineWander(place.GetComponent<PathNode>());
            }
            else
            {
                _coroutineMove = CoroutineMove(_wayPoints);
            }
            StartCoroutine(_coroutineMove);
            yield return new WaitForSeconds(_timeIntervalSearchWay);
            StopCoroutine(_coroutineMove);
            _coroutineThink = ÑoroutineSearchEnemy();
            StartCoroutine(_coroutineThink);
        }
    }

 
}