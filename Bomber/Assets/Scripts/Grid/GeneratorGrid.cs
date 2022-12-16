using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Pathfinder;
using Bomber.Enemies;
using Bomber.Global;
using Bomber.ObjectPooled;

namespace Bomber.Grid
{
    public class GeneratorGrid : MonoBehaviour
    {



        [SerializeField] private List<PathNode> _pathNodes = new List<PathNode>();

        private Level _level;
        private FactoryEnemy _factoryEnemy;
        private LevelManager _levelManager;

        [SerializeField] private GameObject _placePlayer;


        public void Setup(Level currentLevel, FactoryEnemy factoryEnemy, LevelManager levelManager)
        {
            _level = currentLevel;
            _factoryEnemy = factoryEnemy;
            _levelManager = levelManager;
            for (int i = 0; i < _level.SizeLevel.x; i++)
            {
                for (int j = 0; j < _level.SizeLevel.y; j++)
                {

                    var cell = ObjectPool.instance.GetObject(_level.Blocks[i * _level.SizeLevel.y + j].TypeBlockInObjectPool);
                    _pathNodes.Add(cell.GetComponent<PathNode>());
                    if (cell.TryGetComponent(out Water water))
                    {
                        SetupWaterBlock(water, i, j);
                    }
                    if (cell.TryGetComponent(out Ground ground))
                    {
                        SetupGroundBlock(ground, i, j);
                    }
                    if (_level.StartPoint.x == i && _level.StartPoint.y == j)
                    {
                        _placePlayer = cell;
                    }
                }
            }
            SetupNeghbours();
        }
        public void SetupWaterBlock(Water water, int i, int j)
        {
            water.transform.position = new Vector3(transform.position.x + i, -0.5f, transform.position.z + j);
            switch (_level.Blocks[i * _level.SizeLevel.y + j].WaterObject)
            {
                case TypeObjectOnWater.Bridge:
                    CreateObject(TypeObjectInPool.Bridge, water.transform, 0.5f);
                    break;
                case TypeObjectOnWater.Ice:
                    water.CreateIce();
                    break;

            }
        }

        public void SetupGroundBlock(Ground ground, int i, int j)
        {
            ground.transform.position = new Vector3(transform.position.x + i, 0, transform.position.z + j);
            switch (_level.Blocks[i * _level.SizeLevel.y + j].GroundObject)
            {
                case TypeObjectOnGround.WoodenWall:
                    CreateObject(TypeObjectInPool.WoodWall, ground.transform, 1);
                    break;
                case TypeObjectOnGround.MetalWall:
                    CreateObject(TypeObjectInPool.MetalWall, ground.transform, 0.5f);
                    break;
                case TypeObjectOnGround.SpawnerEnemy:
                    CreateObject(TypeObjectInPool.EnemySpawn, ground.transform, 0);
                    _factoryEnemy.AddPlace(ground.transform);
                    break;
                case TypeObjectOnGround.Star:
                    CreateObject(TypeObjectInPool.Star, ground.transform, 0.5f);
                    _levelManager.AddMaxStars();
                    break;
                case TypeObjectOnGround.Exit:
                    CreateObject(TypeObjectInPool.Exit, ground.transform, 0f);
                    break;
            }
        }

        public GameObject CreateObject(TypeObjectInPool type, Transform place, float offsetY)
        {
            var obj = ObjectPool.instance.GetObject(type);
            obj.transform.position = new Vector3(place.position.x, place.position.y + offsetY, place.transform.position.z);
            return obj;
        }
        
        public void SetupNeghbours()
        {
            for (int i = 0; i < _pathNodes.Count; i++)
            {
                _pathNodes[i].name = i.ToString();
                int idUp = i + 1;
                if (idUp % _level.SizeLevel.y != 0 && idUp < _pathNodes.Count)
                {
                    _pathNodes[i].AddNeighbour(_pathNodes[idUp]);
                }

                int idDown = i - 1;
                if (i % _level.SizeLevel.y != 0)
                {
                    _pathNodes[i].AddNeighbour(_pathNodes[idDown]);
                }

                int idRight = i + _level.SizeLevel.y;
                if (idRight < _pathNodes.Count)
                {
                    _pathNodes[i].AddNeighbour(_pathNodes[idRight]);
                }
                int idLeft = i - _level.SizeLevel.y;
                if (idLeft >= 0)
                {
                    _pathNodes[i].AddNeighbour(_pathNodes[idLeft]);
                }
            }
        }

        public GameObject GetStartPoint()
        {
            return _placePlayer;
        }



    }
}
