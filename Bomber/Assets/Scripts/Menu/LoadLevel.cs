using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bomber.Menu
{
    public class LoadLevel : MonoBehaviour
    {
        [SerializeField] private int _numberLevel;
        public void Load()
        {
            PlayerPrefs.SetInt(Constant.CurrentLevel, _numberLevel);
            SceneManager.LoadScene(Constant.SceneGame);
        }
    }
}
