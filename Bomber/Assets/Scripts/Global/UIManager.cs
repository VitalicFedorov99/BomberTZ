using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Bomber.Global
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image _weapon;
        [SerializeField] private TMP_Text _textStars;
        [SerializeField] private TMP_Text _textHealth;
        [SerializeField] private TMP_Text _textTimer;


        [SerializeField] private Sprite[] _spriteWeapons;

        public void UpdateWeapon(int number)
        {
            _weapon.sprite = _spriteWeapons[number];
        }

        public void UpdateCountStars(int countStars, int maxStars)
        {
            _textStars.text = countStars.ToString() + "/" + maxStars.ToString();
        }

        public void UpdateHealth(int health)
        {
            _textHealth.text = health.ToString();
        }

        public void UpdateTimer(float timer)
        {
            _textTimer.text = Mathf.Round(timer).ToString();
        }


    }
}
