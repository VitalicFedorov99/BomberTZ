using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _counterStars;
    [SerializeField] private int _maxStars;
    [SerializeField] private VictoryOrLose _victoryOrLose;
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

    public void Win()
    {
        _victoryOrLose.WinGame(_counterStars, _maxStars);
    }

    public void Lose()
    {
        _victoryOrLose.LoseGame();
    }
}
