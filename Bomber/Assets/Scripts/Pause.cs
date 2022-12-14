using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void OnPause() 
    {
        Time.timeScale = 0;
    }

    public void OffPause() 
    {
        Time.timeScale = 1;
    }
}
