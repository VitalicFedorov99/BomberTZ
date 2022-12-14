using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBang : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out InputHero hero)) 
        {
            
        }
    }
}
