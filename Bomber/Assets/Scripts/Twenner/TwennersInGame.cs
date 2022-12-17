using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
using TMPro;
public class TwennersInGame : MonoBehaviour
{
    [SerializeField] private Image _imageAttack;
    [SerializeField] private Image _imageNextLevel;
    [SerializeField] private TMP_Text _textNumberLevel;
    [SerializeField] private Image _imageLoad;
    [SerializeField] private float _timeDamage;
    [SerializeField] private float _timeNextLevel;
    public void Damage()
    {
        _imageAttack.gameObject.SetActive(true);
        _imageAttack.DOFade(0, _timeDamage);
        StartCoroutine(CoroutineDamage());
    }

    public void SwitchActiveImageLoad(bool flag) 
    {
        _imageLoad.gameObject.SetActive(flag);
    }

    public void Nextlevel( int numberLevel) 
    {
        _textNumberLevel.text = "Уровень - " + numberLevel.ToString();
        _imageNextLevel.gameObject.SetActive(true);
        _imageNextLevel.DOFade(0, _timeNextLevel);
        _textNumberLevel.DOFade(0, _timeNextLevel);
        StartCoroutine(CoroutineLoadLevel());
    }

    public float GetTimeNextLevel() 
    {
        return _timeNextLevel;
    }


    IEnumerator CoroutineDamage() 
    {
        yield return new WaitForSeconds(_timeDamage);
        _imageAttack.gameObject.SetActive(false);
        _imageAttack.DOFade(1, 0);
    }

    IEnumerator CoroutineLoadLevel() 
    {
        yield return new WaitForSeconds(_timeNextLevel);
        _imageNextLevel.DOFade(1, 0);
        _textNumberLevel.DOFade(1, 0);
        _imageNextLevel.gameObject.SetActive(false);
    }


}
