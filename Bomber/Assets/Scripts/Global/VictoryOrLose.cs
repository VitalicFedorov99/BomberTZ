using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Bomber.Global
{
    public class VictoryOrLose : MonoBehaviour
    {
        [SerializeField] private GameObject _victory;
        [SerializeField] private GameObject _lose;
        [SerializeField] private GameObject _canvasEndGame;
        [SerializeField] private GameObject _buttonNewtLevel;
        [SerializeField] private TMP_Text _textResult;
        [SerializeField] private Pause _pause;
        [SerializeField] private AudioClip _victorySound;
        [SerializeField] private AudioClip _loseSound;
        [SerializeField] private AudioSource _audio;



        [SerializeField] private Setuper _setuper;
        public void LoseGame()
        {
            //_setuper.StopAudio();
            //_audio.clip = _loseSound;
            //_audio.gameObject.SetActive(true);
            //_audio.Play();
           
            _canvasEndGame.SetActive(true);
            _lose.SetActive(true);
            _pause.OnPause();
            _setuper.StopAudio();
            _audio.clip = _loseSound;
            _audio.gameObject.SetActive(true);
            _audio.Play();
        }

        public void WinGame(int countStars, int maxStars, int level, float time, int health)
        {
            _setuper.StopAudio();
            _audio.clip = _victorySound;
            _audio.gameObject.SetActive(true);
            _audio.Play();
            _canvasEndGame.SetActive(true);
            _victory.SetActive(true);
            _textResult.text = countStars.ToString() + "/" + maxStars.ToString();
            if (level < _setuper.GetCountLevels())
            {
                _buttonNewtLevel.SetActive(true);
            }
            SaveResult(countStars, maxStars, level, time, health);
            _pause.OnPause();
        }

        public void OffCanvas() 
        {

            _canvasEndGame.SetActive(false);
            _lose.SetActive(false);
            _victory.SetActive(false);
            _buttonNewtLevel.SetActive(false);
            _audio.gameObject.SetActive(false);
        }

        private void SaveResult(int countStars, int maxStars, int level, float time, int health)
        {
            PlayerPrefs.SetInt(Constant.MaxStars + level, maxStars);
            var MaxCountStars = PlayerPrefs.GetInt(Constant.CountStars + level, 0);
            if (MaxCountStars < countStars)
            {
                PlayerPrefs.SetInt(Constant.CountStars + level, countStars);

            }
            var life = PlayerPrefs.GetInt(Constant.Health + level, 0);
            if (life < health)
            {
                PlayerPrefs.SetInt(Constant.Health + level, health);

            }
            var timer = PlayerPrefs.GetFloat(Constant.Timer + level, 100000);
            if (time < timer)
            {
                PlayerPrefs.SetFloat(Constant.Timer + level, time);
            }
        }



    }
}
