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
       
        _pause.OnPause();
    }
    

    private void SaveResult(int countStars, int maxStars, int level, float time, int health) 
    {
        //var MaxcountStars =PlayerPrefs.GetInt()
    }
    private IEnumerator CoroutineLose() 
    {
        yield return new WaitForSeconds(_time);
        _canvasEndGame.SetActive(true);
        _lose.SetActive(true);
        _pause.OnPause();
    }



}
