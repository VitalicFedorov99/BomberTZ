using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Pathfinder;
using Bomber.ObjectPooled;
using Bomber.PlayerSystem;


namespace Bomber.Enemies
{
    public class FactoryEnemy : MonoBehaviour
    {

        [SerializeField] private Player _player;
        [SerializeField] private PathFinder _pathFinder;
        [SerializeField] private List<Transform> _places;
        [SerializeField] private float _time;

        public void Setup()
        {
            _places = new List<Transform>();
        }

        public void AddPlace(Transform place)
        {
            _places.Add(place);
        }
        public void StartSpawned()
        {
            StartCoroutine(CoroutineSpawn());
        }

        public void CreateUnit()
        {
            if (_places.Count > 0)
            {
                var rand = Random.Range(0, _places.Count);
                GameObject enemy = ObjectPool.instance.GetObject(TypeObjectInPool.EnemyRed);
                enemy.transform.position = new Vector3(_places[rand].position.x, _places[rand].position.y + 0.1f, _places[rand].position.z);
                enemy.GetComponent<Enemy>().Setup(_pathFinder, _player);
            }
        }

        private IEnumerator CoroutineSpawn()
        {
            CreateUnit();
            yield return new WaitForSeconds(_time);
            StartCoroutine(CoroutineSpawn());
        }


    }
}