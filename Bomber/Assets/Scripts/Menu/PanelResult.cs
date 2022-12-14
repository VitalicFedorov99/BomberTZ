using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
public class PanelResult : MonoBehaviour
{
    [SerializeField] private TMP_Text _textLife;
    [SerializeField] private TMP_Text _textTimer;
    [SerializeField] private TMP_Text _textStars;
    [SerializeField] private Image _imageStar;
    [SerializeField] private Image _imageHealth;
    [SerializeField] private Image _imageTimer;
    [SerializeField] private Image _panel;
    
    private int _numberLevel;


    public void Fade(int endValue, float timer) 
    {
        _textLife.DOFade(endValue, timer);
        _textTimer.DOFade(endValue, timer);
        _textStars.DOFade(endValue, timer);
        _imageStar.DOFade(endValue, timer);
        _imageHealth.DOFade(endValue, timer);
        _imageTimer.DOFade(endValue, timer);
        _panel.DOFade(endValue, timer);
    }
    public void UpdateInfo()
    {
       
    }

}
