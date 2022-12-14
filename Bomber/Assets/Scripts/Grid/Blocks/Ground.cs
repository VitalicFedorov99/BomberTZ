using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private TypeObjectOnGround _typeObjecOnGround;

    public TypeObjectOnGround GetTypeObjectOnGround() 
    {
        return _typeObjecOnGround;
    }
}



public enum TypeObjectOnGround 
{
    Nun,
    WoodenWall,
    SteelWall,
    SpawnerEnemy,
    Star,
    Exit
}
