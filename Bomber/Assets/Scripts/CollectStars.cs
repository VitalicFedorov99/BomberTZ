using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStars : MonoBehaviour
{

     private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Stars star))
        {
            _player.AddStar();
            Destroy(star.gameObject);
        }
        if( other.TryGetComponent(out Exit exit)) 
        {
            _player.Exit();
        }
    }
}
