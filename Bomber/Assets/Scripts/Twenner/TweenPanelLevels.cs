using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;
public class TweenPanelLevels : MonoBehaviour
{
    [SerializeField] private Image _levels;
    [SerializeField] private float _timeFade;
    public void Fade(int fade)
    {
        _levels.DOFade(fade, _timeFade);
    }
}
