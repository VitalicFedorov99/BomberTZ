using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private GameObject _buttonMenu;
    [SerializeField] private PanelResult _panelResult;

    public void Off()
    {
        foreach(var  level in _levels)
        {
            level.SetActive(false);
        }
        _buttonMenu.SetActive(false);
        _panelResult.gameObject.SetActive(false);
    }

    public void On()
    {
        foreach (var level in _levels)
        {
            level.SetActive(true);
        }
        _buttonMenu.SetActive(true);
        _panelResult.gameObject.SetActive(true);
    }
}
