using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{


    [SerializeField] private string _nameScene;


    public void Load()
    {
        SceneManager.LoadScene(_nameScene);
    }
}
