using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bomber.ObjectPooled
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool instance;


        [SerializeField] private List<ObjectInfo> _objectsInfo;

        [SerializeField] private Dictionary<TypeObjectInPool, Pool> _pools;

        private void Awake()
        {
            instance = this;
        }
        public void InitPool()
        {
            _pools = new Dictionary<TypeObjectInPool, Pool>();

            var emptyGo = new GameObject();

            foreach (var obj in _objectsInfo)
            {
                var container = Instantiate(emptyGo, transform, false);
                container.name = obj.TypeObject.ToString();
                _pools[obj.TypeObject] = new Pool(container.transform);
                for (int i = 0; i < obj.StartCount; i++)
                {

                    var go = InstantiateObject(obj.TypeObject, container.transform);
                    _pools[obj.TypeObject].Objects.Enqueue(go);
                }
            }

            Destroy(emptyGo);
        }

        public GameObject GetObject(TypeObjectInPool type)
        {
            GameObject obj;
            if (_pools[type].Objects.Count > 0)
            {
                obj = _pools[type].Objects.Dequeue();
            }
            else
            {
                obj = InstantiateObject(type, _pools[type].Container);
            }
            obj.SetActive(true);

            return obj;
        }

        public void DestroyObject(GameObject obj)
        {
            _pools[obj.GetComponent<IPooledObject>().TypeObject].Objects.Enqueue(obj);
            obj.SetActive(false);
        }

        private GameObject InstantiateObject(TypeObjectInPool type, Transform parent)
        {
            var go = Instantiate(_objectsInfo.Find(x => x.TypeObject == type).Prefab, parent);
            go.SetActive(false);
            return go;
        }
    }

    public enum TypeObjectInPool
    {
        Ground,
        Water,
        EnemyRed,
        Bomb,
        IceBomb,
        IceEffect,
        FireEffect,
        Bridge,
        MetalWall,
        WoodWall,
        EnemySpawn,
        Star,
        Exit
    }

    [Serializable]
    public struct ObjectInfo
    {
        public TypeObjectInPool TypeObject;
        public GameObject Prefab;
        public int StartCount;
    }
}