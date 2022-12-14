using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private UIManager _ui;


    private void Update()
    {
        _timer += Time.deltaTime;
        _ui.UpdateTimer(_timer);
    }

}
