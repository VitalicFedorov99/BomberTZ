using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bomber.Menu
{
    public class LevelInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _timer;
        [SerializeField] private int _health;
        [SerializeField] private int _stars;
        [SerializeField] private int _maxStars;
        [SerializeField] private int _numberLevel;
        [SerializeField] private PanelResult _panelResult;


        public void OnPointerEnter(PointerEventData eventData)
        {
            _panelResult.UpdateInfo(_health, _stars, _maxStars, _timer);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _panelResult.OffPanel();
        }

        public void UpdateInfo()
        {

            _timer = PlayerPrefs.GetFloat(Constant.Timer + _numberLevel);
            _health = PlayerPrefs.GetInt(Constant.Health + _numberLevel);
            _stars = PlayerPrefs.GetInt(Constant.CountStars + _numberLevel);
            _maxStars = PlayerPrefs.GetInt(Constant.MaxStars + _numberLevel);
        }
        private void Start()
        {
            UpdateInfo();
        }

    }
}