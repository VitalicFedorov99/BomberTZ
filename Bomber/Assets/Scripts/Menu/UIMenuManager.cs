using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private LevelPanel _levelPanel;
    [SerializeField] private TweenPanelLevels _twinnerPanel;
    

    public void Exit()
    {
        Application.Quit();
    }

    public void ClosePanelLevel()
    {
        _levelPanel.Off();
        _twinnerPanel.Fade(0);
        //_levelPanel.SetActive(false);
    }

    public void OpenPanelLevel()
    {
        _levelPanel.Off();
        _twinnerPanel.Fade(1);
        //_levelPanel.SetActive(true);
    }
}
