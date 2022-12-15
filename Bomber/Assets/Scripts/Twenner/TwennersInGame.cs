using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class TwennersInGame : MonoBehaviour
{
    [SerializeField] private Image _imageAttack;
    [SerializeField] private float _time;
    public void Damage()
    {
        _imageAttack.gameObject.SetActive(true);
        _imageAttack.DOFade(0, _time);
        StartCoroutine(CoroutineDamage());
    }

    IEnumerator CoroutineDamage() 
    {
        yield return new WaitForSeconds(_time);
        _imageAttack.gameObject.SetActive(false);
        _imageAttack.DOFade(1, 0);
    }


}
