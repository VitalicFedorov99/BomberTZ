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

        private Player _player;
        [SerializeField] private float _time;
        [SerializeField] private List<Transform> _places;

        public void Setup(Player player)
        {
            _places = new List<Transform>();
            _player = player;
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
                enemy.transform.position = new Vector3(_places[rand].position.x, _places[rand].position.y + 0.3f, _places[rand].position.z);
                enemy.GetComponent<Enemy>().Setup(_player);
            }
        }

        public void StopFactory() 
        {
            StopAllCoroutines();
        }

        private IEnumerator CoroutineSpawn()
        {
            yield return new WaitForSeconds(1f);
            CreateUnit();
            yield return new WaitForSeconds(_time-1f);
            StartCoroutine(CoroutineSpawn());
        }


    }
}