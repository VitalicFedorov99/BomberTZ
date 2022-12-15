using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryOrLose : MonoBehaviour
{
    [SerializeField] private GameObject _victory;
    [SerializeField] private GameObject _lose;
    [SerializeField] private GameObject _canvasEndGame;
    [SerializeField] private TMP_Text _textResult;
    [SerializeField] private Pause _pause;
    [SerializeField] private float _time;

    public void LoseGame()
    {
        StartCoroutine(CoroutineLose());
    }

    public void WinGame(int countStars, int maxStars, int level, float time, int health)
    {
        _canvasEndGame.SetActive(true);
        _victory.SetActive(true);
        _textResult.text = countStars.ToString() + "/" + maxStars.ToString();

        SaveResult(countStars, maxStars, level, time, health);
        _pause.OnPause();
    }


    private void SaveResult(int countStars, int maxStars, int level, float time, int health)
    {
        PlayerPrefs.SetInt(Constant.MaxStars + level, maxStars);
        Debug.Log(PlayerPrefs.GetInt((Constant.MaxStars + level)));
        var MaxCountStars = PlayerPrefs.GetInt(Constant.CountStars + level, 0);
        if (MaxCountStars < countStars)
        {
            PlayerPrefs.SetInt(Constant.CountStars + level, countStars);

        }
        var life = PlayerPrefs.GetInt(Constant.Health + level, 0);
        if (life < health)
        {
            PlayerPrefs.SetInt(Constant.Health + level, health);

        }
        var timer = PlayerPrefs.GetFloat(Constant.Timer + level, 100000);
        if (time < timer)
        {
            PlayerPrefs.SetFloat(Constant.Timer + level, time);
        }

    }
    private IEnumerator CoroutineLose()
    {
        yield return new WaitForSeconds(_time);
        _canvasEndGame.SetActive(true);
        _lose.SetActive(true);
        _pause.OnPause();
    }



}
