using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Grid;

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

    [Header("Levels")]
    [SerializeField] private Level[] _level;
    [SerializeField] private int numberLevel;

    private void Start()
    {
        _objectPool.InitPool();
        _generatorGrid.Setup();
        _factoryEnemy.StartSpawned();
        _uiManager.UpdateCountStars(0, _levelManager.GetMaxStars());
        _pause.OffPause();
        var place = _generatorGrid.GetStartPoint();
        _player.transform.position = new Vector3(place.transform.position.x, place.transform.position.y + 1, place.transform.position.z);
    }


   
}
