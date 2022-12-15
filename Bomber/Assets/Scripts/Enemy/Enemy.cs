using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Bomber.Pathfinder;
using Bomber.ObjectPooled;
using Bomber.PlayerSystem;

namespace Bomber.Enemies
{
    public class Enemy : MonoBehaviour, IPooledObject
    {
        public TypeObjectInPool TypeObject => _type;


        [SerializeField] private float _timeCooldowmAttack;
        [SerializeField] private float _timeDie;

        private TypeObjectInPool _type;
        private AnimationEnemy _animationEnemy;
        private bool _isDead = false;
        private bool _flagCDAttak = true;
        private Player _player;
        private MoveEnemy _move;


        private void Update()
        {
            if (!_isDead)
            {

                if (_flagCDAttak)
                {
                    CheckPlayerForAttack();
                }
                if (transform.position.y < -1f)
                {
                    Die();
                }
            }
            
        }
        public void Setup(Player player)
        {
            _player = player;
            _animationEnemy = GetComponent<AnimationEnemy>();
            _animationEnemy.Setup();
            _move= GetComponent<MoveEnemy>();
            _move.Setup(_player);
            _isDead = false;
        }
        public void DestroyObject()
        {
            ObjectPool.instance.DestroyObject(gameObject);
        }

        public void Die()
        {
            _isDead = true;
            _animationEnemy.StateDie();
            _move.MoveStop();
            StopAllCoroutines();
            StartCoroutine(CoroutineDead());
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

        private IEnumerator CoroutineDead() 
        {
            yield return new WaitForSeconds(_timeDie);
            DestroyObject();
        }

        private IEnumerator CoroutineAttack()
        {
            _animationEnemy.StateAttack();
            _player.TakeDamage(1);
            yield return new WaitForSeconds(_timeCooldowmAttack);
            _flagCDAttak = true;
            _move.Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.TryGetComponent(out Water water)) 
            {
                Die();
            }
        }
    }
}
        