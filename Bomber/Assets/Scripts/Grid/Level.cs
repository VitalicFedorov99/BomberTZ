using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Bomber.ObjectPooled;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Levels", order = 1)]
public class Level : ScriptableObject
{
    public Vector2Int SizeLevel;
    public Vector2Int StartPoint;

    public List<InfoBlockInLevels> Blocks;
}

[Serializable]
public class InfoBlockInLevels
{
   public TypeObjectInPool TypeBlockInObjectPool = TypeObjectInPool.Ground;
   public TypeObjectOnWater WaterObject;
   public TypeObjectOnGround GroundObject;
}




