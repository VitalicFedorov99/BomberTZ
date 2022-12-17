using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Global;
using Bomber.ObjectPooled;

namespace Bomber.PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private TypeObjectInPool _currentBomb = TypeObjectInPool.Bomb;
        [SerializeField] private int _countBomb;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private LevelManager _level;
        [SerializeField] private TwennersInGame _twennersInGame;
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _cooldown;

        private bool _flagCreateBomb = true;
        private int _health;
        private int _numberCurrentBomb = 0;
        private PlayerAnimation _playerAnimation;
        private TypeObjectInPool _bomb = TypeObjectInPool.Bomb;
        private TypeObjectInPool _iceBomb = TypeObjectInPool.IceBomb;

        public void Setup()
        {
            _playerAnimation = GetComponent<PlayerAnimation>();

        }

        public void UpdatePlayer() 
        {
            _health = _maxHealth;
            _uiManager.UpdateHealth(_health);
            _flagCreateBomb = true;
        }
        
        
        public TypeObjectInPool GetCurrentBomb()
        {
            return _currentBomb;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            _playerAnimation.StateTakeDamage();
            _twennersInGame.Damage();
            if (_health <= 0)
            {
                Die();
                _health = 0;
            }
            _uiManager.UpdateHealth(_health);
        }
        public void NextWeapon()
        {
            _numberCurrentBomb++;
            if (_numberCurrentBomb >= _countBomb)
            {
                _numberCurrentBomb = 0;
            }
            ChooseWeapon(_numberCurrentBomb);
            _uiManager.UpdateWeapon(_numberCurrentBomb);
        }

        private void ChooseWeapon(int number)
        {
            switch (number)
            {
                case 0:
                    _currentBomb = _bomb;
                    break;
                case 1:
                    _currentBomb = _iceBomb;
                    break;
            }
        }

        public void AddStar()
        {
            _level.AddStars();
            _uiManager.UpdateCountStars(_level.GetCountStars(), _level.GetMaxStars());
        }
        public void Exit()
        {
            _level.Win(_health);
        }

        public void Die()
        {
            _playerAnimation.StateDie();
            _level.Lose();
        }

        public void Move(bool flag)
        {
            _playerAnimation.StateWalk(flag);
        }
        
        public bool GetFlagCreateBomb() 
        {
            return _flagCreateBomb;
        }

        public void CreateBomb() 
        {
            _flagCreateBomb = false;
            StartCoroutine(CoroutineCooldown());
        }

        private void Update()
        {
            CheckFailed();
        }

        private void CheckFailed()
        {
            if (transform.position.y <= -0.4f)
            {
                TakeDamage(1000);
            }
        }

        private IEnumerator CoroutineCooldown()
        {
            _flagCreateBomb = false;
            yield return new WaitForSeconds(_cooldown);
            _flagCreateBomb = true;

        }
    }
}
