using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Levels", order = 1)]
public class Level : ScriptableObject
{
    public Vector2Int SizeLevel;
    public List<BlockData> Blocks;
    public Vector2Int _startPoint;
    public Vector2Int _endPoint;
    public List<Vector2Int> _enemyPoints;
}



