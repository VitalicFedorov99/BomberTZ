using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TypeObjectInPool _currentBomb = TypeObjectInPool.Bomb;
    [SerializeField] private int _countBomb;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private LevelManager _level;
    [SerializeField] private int _health = 5;

    private int _numberCurrentBomb = 0;
    private PlayerAnimation _playerAnimation;
    private TypeObjectInPool _bomb = TypeObjectInPool.Bomb;
    private TypeObjectInPool _iceBomb = TypeObjectInPool.IceBomb;

   
     private void Start() 
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        CheckFailed();
    }

    public TypeObjectInPool GetCurrentBomb() 
    {
        return _currentBomb;
    }

    public void TakeDamage(int damage) 
    {
        _health -= damage;
        _playerAnimation.StateTakeDamage();
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
    private void CheckFailed() 
    {
        if (transform.position.y <= 0) 
        {
            Die();
        }
    }

  
}
