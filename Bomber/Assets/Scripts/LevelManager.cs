using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _counterStars;
    [SerializeField] private int _maxStars;
    [SerializeField] private VictoryOrLose _victoryOrLose;
    [SerializeField] private int _numberLevel;
    [SerializeField] private Timer _timer;
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
