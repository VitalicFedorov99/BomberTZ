using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
namespace Bomber.Menu
{
    public class TweenPanelLevels : MonoBehaviour
    {
        [Header("Main Menu")]
        [SerializeField] private Image _buttonLevels;
        [SerializeField] private Image _buttonExit;
        [SerializeField] private Image _imageMainMenu;
        [SerializeField] private Image _imageReset;
        [SerializeField] private TMP_Text _textReset;
        [SerializeField] private TMP_Text _textLevels;
        [SerializeField] private TMP_Text _textExit;
        [SerializeField] private TMP_Text _textNameGame;

        public void Fade(int endValue, float time)
        {
            _imageMainMenu.gameObject.SetActive(true);
            _buttonLevels.DOFade(endValue, time);
            _buttonExit.DOFade(endValue, time);
            _imageMainMenu.DOFade(endValue, time);
            _textExit.DOFade(endValue, time);
            _textLevels.DOFade(endValue, time);
            _textNameGame.DOFade(endValue, time);
            _imageReset.DOFade(endValue, time);
            _textReset.DOFade(endValue, time);
        }

        public IEnumerator CoroutineOff(float time)
        {
            yield return new WaitForSeconds(time);
            _imageMainMenu.gameObject.SetActive(false);
        }
    }
}
