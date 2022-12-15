using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Pathfinder;
using Bomber.Enemies;
using Bomber.Global;

namespace Bomber.Grid
{
    public class GeneratorGrid : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabGrid;
        [SerializeField] private BlockData _water;
        [SerializeField] private List<PathNode> _pathNodes = new List<PathNode>();

        private Level _level;
        private FactoryEnemy _factoryEnemy;
        private LevelManager _levelManager;

        [SerializeField] private GameObject _placePlayer;
        
        [Header("Prefabs")]
        [SerializeField] GameObject _woodWall;
        [SerializeField] GameObject _steelWall;
        [SerializeField] GameObject _bridge;
       
        public void Setup(Level currentLevel, FactoryEnemy factoryEnemy, LevelManager levelManager)
        {
            _level = currentLevel;
            _factoryEnemy = factoryEnemy;
            _levelManager = levelManager;
            for (int i = 0; i <_level.SizeLevel.x; i++)
            {
                for (int j = 0; j < _level.SizeLevel.y; j++)
                {
                    if (_level.Blocks[i * _level.SizeLevel.y + j] != null)
                    {
                        var cell = Instantiate(_level.Blocks[i * _level.SizeLevel.y + j], new Vector3(transform.position.x + i, 0, transform.position.z + j), Quaternion.identity,transform);
                        SetupObject(cell);
                        _pathNodes.Add(cell.GetComponent<PathNode>());
                        if (_level.StartPoint.x == i && _level.StartPoint.y == j)
                        {
                            _placePlayer = cell.gameObject;
                        }
                    }
                    else
                    {
                        var cell = Instantiate(_water, new Vector3(transform.position.x + i, -0.5f, transform.position.z + j), Quaternion.identity,transform);
                        _pathNodes.Add(cell.GetComponent<PathNode>());
                    }
                    
                }
            }

            SetupNeghbours();
        }

        public void SetupObject(BlockData block)
        {
            if (block.GetTypeBlock() == TypeBlock.Ground)
            {
                if (block.GetComponent<Ground>().GetTypeObjectOnGround() == TypeObjectOnGround.WoodenWall)
                {
                    var wall = Instantiate(_woodWall, new Vector3(block.transform.position.x, block.transform.position.y + 1, block.transform.position.z), Quaternion.identity,transform);
                }
                if (block.GetComponent<Ground>().GetTypeObjectOnGround() == TypeObjectOnGround.SteelWall)
                {
                    var wall = Instantiate(_steelWall, new Vector3(block.transform.position.x, block.transform.position.y + 0.5f, block.transform.position.z), Quaternion.identity,transform);
                }
                if(block.GetComponent<Ground>().GetTypeObjectOnGround() == TypeObjectOnGround.SpawnerEnemy) 
                {
                    _factoryEnemy.AddPlace(block.transform);
                }
                if (block.GetComponent<Ground>().GetTypeObjectOnGround() == TypeObjectOnGround.Star) 
                {
                    _levelManager.AddMaxStars();
                }
                
            }
            if (block.GetTypeBlock() == TypeBlock.Water)
            {
                block.transform.position = new Vector3(block.transform.position.x, -0.5f, block.transform.position.z);
                if (block.GetComponent<Water>().GetStateWaterBlock() == StateWaterBlock.Bridge)
                {

                    var bridge = Instantiate(_bridge, new Vector3(block.transform.position.x, block.transform.position.y + 0.5f, block.transform.position.z), Quaternion.identity);
                }
                if (block.GetComponent<Water>().GetStateWaterBlock() == StateWaterBlock.Ice)
                {
                    block.GetComponent<Water>().CreateIce();
                }
            }
        }

        public void SetupNeghbours()
        {
            foreach (PathNode pathNode in _pathNodes)
            {
                RaycastHit[] hitsHorizontal = Physics.RaycastAll(new Vector3(pathNode.transform.position.x - 2, pathNode.transform.position.y, pathNode.transform.position.z), Vector3.right, 3);
                RaycastHit[] hitsVertical = Physics.RaycastAll(new Vector3(pathNode.transform.position.x, pathNode.transform.position.y, pathNode.transform.position.z - 2), Vector3.forward, 3);
                RaycastHit[] hitsHorizontal2 = Physics.RaycastAll(new Vector3(pathNode.transform.position.x -  2, pathNode.transform.position.y - 1, pathNode.transform.position.z), Vector3.right,3);
                RaycastHit[] hitsVertical2 = Physics.RaycastAll(new Vector3(pathNode.transform.position.x, pathNode.transform.position.y - 1, pathNode.transform.position.z - 2), Vector3.forward,3);

                foreach(var hit in hitsHorizontal) 
                {
                    pathNode.AddNeighbour(hit.collider.GetComponent<PathNode>());
                }
                foreach (var hit in hitsHorizontal2)
                {
                    pathNode.AddNeighbour(hit.collider.GetComponent<PathNode>());
                }
                foreach (var hit in hitsVertical)
                {
                    pathNode.AddNeighbour(hit.collider.GetComponent<PathNode>());
                }
                foreach (var hit in hitsVertical2)
                {
                    pathNode.AddNeighbour(hit.collider.GetComponent<PathNode>());
                }
            }
        }

        public GameObject GetStartPoint() 
        {
            return _placePlayer;
        }

        
    }
}
