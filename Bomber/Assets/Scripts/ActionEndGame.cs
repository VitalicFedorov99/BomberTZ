using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActionEndGame : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
