using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bomber.Global
{
    public class ActionEndGame : MonoBehaviour
    {
        [SerializeField] private Setuper _setuper;
        public void Restart()
        {
            _setuper.Restart();
        }

        public void Menu()
        {
            SceneManager.LoadScene(Constant.SceneMenu);
        }

        public void NextLevel() 
        {
            _setuper.NumberLevelInc();
        }
    }
}