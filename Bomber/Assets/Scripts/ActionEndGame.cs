using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActionEndGame : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(Constant.SceneGame);
    }

    public void Menu() 
    {
        SceneManager.LoadScene(Constant.SceneMenu);
    }
}
