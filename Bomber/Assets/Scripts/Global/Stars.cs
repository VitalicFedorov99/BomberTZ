using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] private float _speed;
    

    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x, 90, transform.rotation.z) * Time.deltaTime * _speed);
    }
}
