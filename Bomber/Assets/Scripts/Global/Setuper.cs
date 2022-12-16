using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Grid;
using Bomber.Enemies;
using Bomber.ObjectPooled;
using Bomber.PlayerSystem;

namespace Bomber.Global
{
    public class Setuper : MonoBehaviour
    {

        [Header("Systems")]
        [SerializeField] private ObjectPool _objectPool;
        [SerializeField] private FactoryEnemy _factoryEnemy;
        [SerializeField] private Player _player;
        [SerializeField] private GeneratorGrid _generatorGrid;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private Pause _pause;
        [SerializeField] private VictoryOrLose _victoryOrLose;
        [SerializeField] private Timer _timer;

        [Header("Levels")]
        [SerializeField] private Level[] _levels;
        private int _numberLevel;

        private void Start()
        {
            _pause.OffPause(); 
            _numberLevel = PlayerPrefs.GetInt(Constant.CurrentLevel, 0);
            SetupSystem();
            SetupPlayer();
            _factoryEnemy.StartSpawned();
        }

        private void SetupSystem() 
        {
            _objectPool.InitPool();
            _factoryEnemy.Setup(_player);
            _generatorGrid.Setup(_levels[_numberLevel - 1], _factoryEnemy, _levelManager);
            _uiManager.UpdateCountStars(0, _levelManager.GetMaxStars());
            _levelManager.Setup(_numberLevel, _timer, _victoryOrLose);
        }

        private void SetupPlayer()
        {
            var place = _generatorGrid.GetStartPoint();
            _player.transform.position = new Vector3(place.transform.position.x, place.transform.position.y + 1, place.transform.position.z);
            _player.Setup();
        }
    }
}