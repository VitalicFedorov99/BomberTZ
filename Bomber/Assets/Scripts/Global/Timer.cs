using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomber.Global
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private UIManager _ui;
        private float _timer;
        private bool _isWork = false;


        public void Reset()
        {
            _isWork = true;
            _timer = 0;
        }

        public void Stop()
        {
            _isWork = false;
        }

        public float GetTimer()
        {
            return _timer;
        }
        private void Update()
        {
            if (_isWork)
            {
                _timer += Time.deltaTime;
                _ui.UpdateTimer(_timer);
            }
        }

    }
}
