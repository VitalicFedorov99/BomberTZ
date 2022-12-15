using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _objectFollow;
    [SerializeField] private Vector3 _deltaPos;
    void Start()
    {
        _deltaPos = transform.position - _objectFollow.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _objectFollow.position + _deltaPos;
    }
}
