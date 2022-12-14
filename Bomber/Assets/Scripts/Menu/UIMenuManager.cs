using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private LevelPanel _levelPanel;
    [SerializeField] private TweenPanelLevels _twinnerPanel;
    [SerializeField] private GameObject _panelAgainstRaycast;
    [SerializeField] private float _time;
    public void Exit()
    {
        Application.Quit();
    }

    public void ClosePanelLevel()
    {
        StartCoroutine(CoroutineONOffPanel());
        StartCoroutine(_twinnerPanel.CoroutineOff(_time));
        _twinnerPanel.Fade(0, _time);
    }

    public void OpenPanelLevel()
    {
        
        StartCoroutine(CoroutineONOffPanel());
        _twinnerPanel.Fade(1, _time);

    }

    IEnumerator CoroutineONOffPanel()
    {
        _panelAgainstRaycast.SetActive(true);
        yield return new WaitForSeconds(_time);
        _panelAgainstRaycast.SetActive(false);
    }
}
