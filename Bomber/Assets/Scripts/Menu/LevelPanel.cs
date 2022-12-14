using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class LevelPanel : MonoBehaviour
{
    [SerializeField] private Image _levelPanel;
    [SerializeField] private Image[] _levels;
    [SerializeField] private TMP_Text[] _numberLevels;
    [SerializeField] private TMP_Text _textMenu;
    [SerializeField] private Image _buttonMenu;
    [SerializeField] private PanelResult _panelResult;
    [SerializeField] private float _time;
    public void Off()
    {

        _levelPanel.DOFade(0, _time);


        for (int i = 0; i < _numberLevels.Length; i++)
        {
            _numberLevels[i].DOFade(0, _time);
            _levels[i].DOFade(0, _time);

        }
        _textMenu.DOFade(0, _time);
        _buttonMenu.DOFade(0, _time);
        _panelResult.Fade(0, _time);
        StartCoroutine(CoroutineOff());
    }

    public void On()
    {

        _levelPanel.gameObject.SetActive(true);
        _levelPanel.DOFade(1, _time);


        for (int i = 0; i < _numberLevels.Length; i++)
        {
            _numberLevels[i].DOFade(1, _time);
            _levels[i].DOFade(1, _time);

        }
        _textMenu.DOFade(1, _time);
        _buttonMenu.DOFade(1, _time);
        _panelResult.Fade(1, _time);
        


    }

    IEnumerator CoroutineOff() 
    {
        yield return new WaitForSeconds(_time);
        _levelPanel.gameObject.SetActive(false);
    }

 /*   IEnumerator CoroutineFade(bool flag) 
    {
        yield return new WaitForSeconds(_time);
        _levelPanel.SetActive(flag);
    }
    IEnumerator CoroutineFade2() 
    {
        yield return new WaitForSeconds(_time);
        foreach (var level in _levels)
        {
            level.SetActive(true);
        }
        _buttonMenu.SetActive(true);
        _panelResult.gameObject.SetActive(true);
    }*/
}
