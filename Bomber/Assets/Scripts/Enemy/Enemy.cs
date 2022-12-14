using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//[RequireComponent(typeof(LocatePosition))]
public class Enemy : MonoBehaviour, IPooledObject
{
    [SerializeField] private StateEnemy _state;
    [SerializeField] private float _speed;
    [SerializeField] private PathFinder _pathFinder;
    [SerializeField] private TypeObjectInPool _type;
    [SerializeField] private List<PathNode> _wayPoints;
    [SerializeField] private int _counterWay;
    [SerializeField] private float _timeIntervalSearchWay;
    [SerializeField] private float _timeCooldowmAttack;
    [SerializeField] private PathNode _playerNode;
    [SerializeField] private bool _flagCDAttak = true;
    private LocatePosition _locatePosition;
    private AnimationEnemy _animationEnemy;

    private Player _player;
    private IEnumerator _coroutineMove;
    private IEnumerator _coroutineThink;
    private IEnumerator _coroutineAttack;
    public TypeObjectInPool TypeObject => _type;


    public void Setup(PathFinder pathfinder, Player player)
    {
        _pathFinder = GetComponent<PathFinder>();
        //_pathFinder = pathfinder;
        _player = player;
        _locatePosition = GetComponent<LocatePosition>();
        _wayPoints = new List<PathNode>();
        _animationEnemy = GetComponent<AnimationEnemy>();
        _animationEnemy.Setup();
        Move();
    }

    public void Die()
    {
        _animationEnemy.StateDie();
        StopAllCoroutines();
        DestroyObject();
    }

    public void Move()
    {
        _coroutineThink = �oroutineSearchEnemy();
        StartCoroutine(_coroutineThink);
    }


    private IEnumerator CoroutineMove(List<PathNode> wayPoints)
    {
        _counterWay = wayPoints.Count;
        int i = 0;
        var currentPoint = wayPoints[i];
        CheckWater();
        while (Vector3.Distance(transform.position, wayPoints[_counterWay - 1].transform.position) > 0.2f)
        {
            Vector3 currentPos = new Vector3(currentPoint.transform.position.x, transform.position.y, currentPoint.transform.position.z);
            transform.position =
                Vector3.MoveTowards(transform.position, currentPos, _speed * Time.deltaTime);
            transform.LookAt(currentPos);
            CheckPlayerForAttack();
            if ((Vector3.Distance(transform.position, currentPos) < 0.1f && i < _counterWay))
            {
                i++;
                currentPoint = wayPoints[i];
            }
            yield return null;
        }
    }


    private IEnumerator CoroutineWander(PathNode node)
    {
        var neighbours = node.GetNeighbours();
        int rand = Random.Range(0, neighbours.Count);
        CheckWater();
        while (neighbours[rand].GetStatePathNode() == StatePathNode.NoWalkable)
        {
            rand = Random.Range(0, neighbours.Count);
        }
        var neighnour = neighbours[rand];
        while (Vector3.Distance(transform.position, neighnour.transform.position) > 0.7f)
        {
            Vector3 currentPos = new Vector3(neighnour.transform.position.x, transform.position.y, neighnour.transform.position.z);
            transform.position =
                Vector3.MoveTowards(transform.position, currentPos, _speed * Time.deltaTime);
            transform.LookAt(currentPos);
            CheckPlayerForAttack();
            yield return null;
        }
        _coroutineMove = CoroutineWander(neighnour);
        StartCoroutine(_coroutineMove);
    }

    private IEnumerator CoroutineFall(GameObject place)
    {
        StopCoroutine(_coroutineMove);
        StopCoroutine(_coroutineThink);
        Vector3.MoveTowards(transform.position,place.transform.position, _speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        Die();
    }


    private void CheckWater()
    {
        var place = _locatePosition.SearchPlace();

        if(place.TryGetComponent(out Water water))
        {
            if (water.GetStateWaterBlock() == StateWaterBlock.Nun)
            {
                StartCoroutine(CoroutineFall(place));
            }
        }
    }


    private IEnumerator CoroutineAttack() 
    {
        _animationEnemy.StateAttack();
        _player.TakeDamage(1);
        yield return new WaitForSeconds(_timeCooldowmAttack);
        _flagCDAttak = true;
        CheckPlayerForAttack();
    }

    private IEnumerator �oroutineSearchEnemy()
    {
        Debug.Log("�����");
        _wayPoints.Clear();
        var place = _locatePosition.SearchPlace();
        _player.GetComponent<LocatePosition>().SearchPlace();
        var placePlayer = _player.GetComponent<LocatePosition>().GetPlace();
        _playerNode = placePlayer.GetComponent<PathNode>();
        _pathFinder.FindPath(place.GetComponent<PathNode>(), placePlayer.GetComponent<PathNode>(), out _wayPoints, this);
        if (Vector3.Distance(_wayPoints.Last().transform.position, placePlayer.transform.position) > 0.7)
        {

            _state = StateEnemy.Wander;
            _coroutineMove = CoroutineWander(place.GetComponent<PathNode>());
        }
        else
        {
            _state = StateEnemy.Walk;
            _coroutineMove = CoroutineMove(_wayPoints);
        }
        StartCoroutine(_coroutineMove);
        yield return new WaitForSeconds(_timeIntervalSearchWay);
        StopCoroutine(_coroutineMove);
        _coroutineThink = �oroutineSearchEnemy();
        StartCoroutine(_coroutineThink);
    }

    

    private void CheckPlayerForAttack()
    {
        Vector3 playerPos = _player.transform.position;
        Vector3 enemyPos = transform.position;
        if (Vector3.Distance(playerPos, enemyPos) <= 1 && _flagCDAttak)
        {
            transform.LookAt(_player.transform.position);
            _flagCDAttak = false;
            StartCoroutine(CoroutineAttack());
        }
    }

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}

public enum StateEnemy
{
    Walk,
    Think,
    Attack,
    Wander

}
