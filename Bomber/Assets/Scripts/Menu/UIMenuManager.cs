using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Bomber.Menu
{
    public class UIMenuManager : MonoBehaviour
    {
        [SerializeField] private TweenPanelLevels _twinnerPanel;
        [SerializeField] private GameObject _panelAgainstRaycast;
        [SerializeField] private float _time;
        [SerializeField] private LevelInfo[] _levelsInfo;
        public void Exit()
        {
            Application.Quit();
        }

        private void Start()
        {
            Time.timeScale = 1;
        }
        public void ClosePanelLevel()
        {
            StartCoroutine(CoroutineONOffPanel());
            StartCoroutine(_twinnerPanel.CoroutineOff(_time));
            _twinnerPanel.Fade(0, _time);
        }

        public void OpenPanelLevel()
        {

            StartCoroutine(CoroutineONOffPanel());
            _twinnerPanel.Fade(1, _time);

        }

        public void ResetPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            foreach (var info in _levelsInfo)
            {
                info.UpdateInfo();
            }
        }

        private IEnumerator CoroutineONOffPanel()
        {
            _panelAgainstRaycast.SetActive(true);
            yield return new WaitForSeconds(_time);
            _panelAgainstRaycast.SetActive(false);
        }
    }
}
