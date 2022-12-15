using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bomber.Global
{
    public class LevelManager : MonoBehaviour
    {
        private int _counterStars;
        private int _maxStars;
        private VictoryOrLose _victoryOrLose;
        private int _numberLevel;
        private Timer _timer;


        public void Setup(int level, Timer timer, VictoryOrLose victoryOrLose)
        {
            _numberLevel = level;
            _timer = timer;
            _victoryOrLose = victoryOrLose;
        }

        public int GetMaxStars()
        {
            return _maxStars;
        }

        public int GetCountStars()
        {
            return _counterStars;
        }

        public void AddMaxStars()
        {
            _maxStars++;
        }

        public void AddStars()
        {
            _counterStars++;
        }

        public void Win(int healthPlayer)
        {
            _victoryOrLose.WinGame(_counterStars, _maxStars, _numberLevel, _timer.GetTimer(), healthPlayer);
        }

        public void Lose()
        {
            _victoryOrLose.LoseGame();
        }
    }
}