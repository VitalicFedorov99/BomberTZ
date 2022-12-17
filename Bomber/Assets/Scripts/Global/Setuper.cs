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
        [SerializeField] private TwennersInGame _twennersInGame;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private float _timeClear;
        [SerializeField] private float _timeStartGame;
        [Header("Levels")]
        [SerializeField] private Level[] _levels;

        private int _numberLevel;

        public void NextLevel()
        {
            _pause.OffPause();
            _numberLevel = PlayerPrefs.GetInt(Constant.CurrentLevel);
            _levelManager.Setup(_numberLevel, _timer, _victoryOrLose);
            _twennersInGame.SwitchActiveImageLoad(false);
            _factoryEnemy.Setup(_player);
            _generatorGrid.Setup(_levels[_numberLevel - 1], _factoryEnemy, _levelManager);
            _uiManager.UpdateCountStars(0, _levelManager.GetMaxStars());

        }

        public void StopAudio()
        {
            _audio.Stop();
        }
        public void NumberLevelInc()
        {
            _twennersInGame.SwitchActiveImageLoad(true);
            _pause.OffPause();
            PlayerPrefs.SetInt(Constant.CurrentLevel, _numberLevel + 1);
            ObjectPool.instance.DestroyAll();
            _victoryOrLose.OffCanvas();
            StartCoroutine(CoroutineClear());
        }

        public int GetCountLevels()
        {
            return _levels.Length;
        }

        public void Restart()
        {
            _audio.Stop();
            _twennersInGame.SwitchActiveImageLoad(true);
            _pause.OffPause();
            ObjectPool.instance.DestroyAll();
            _victoryOrLose.OffCanvas();
            StartCoroutine(CoroutineClear());
        }

        private void Start()
        {

            SetupSystem();
            _twennersInGame.SwitchActiveImageLoad(true);
            StartCoroutine(CoroutineClear());
        }

        private void SetupSystem()
        {
            _objectPool.InitPool();
            _player.Setup();


        }

        private void SetupPlayer()
        {

            var place = _generatorGrid.GetStartPoint();
            _player.transform.position = new Vector3(place.transform.position.x, place.transform.position.y + 1, place.transform.position.z);
            _player.gameObject.SetActive(true);
            _player.UpdatePlayer();
        }


        private IEnumerator CoroutineClear()
        {
            _player.gameObject.SetActive(false);
            _uiManager.UpdateTimer(0);
            _uiManager.UpdateCountStars(0, 3);
            _factoryEnemy.StopFactory();
            yield return new WaitForSeconds(_timeClear);
            NextLevel();
            StartCoroutine(CoroutineStartGame());
        }

        private IEnumerator CoroutineStartGame()
        {
            _twennersInGame.Nextlevel(_numberLevel);
            yield return new WaitForSeconds(_timeStartGame);
            SetupPlayer();
            _timer.Reset();
            _factoryEnemy.StartSpawned();
            _audio.Play();
        }




    }
}