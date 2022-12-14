using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Grid;

public class Setuper : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private FactoryEnemy _factoryEnemy;
    [SerializeField] private Player _player;
    [SerializeField] private GeneratorGrid _generatorGrid;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Pause _pause;

    private void Start()
    {
        _objectPool.InitPool();
        _generatorGrid.Setup();
        _factoryEnemy.StartSpawned();
        _uiManager.UpdateCountStars(0, _levelManager.GetMaxStars());
        _pause.OffPause(); 
    }
}
