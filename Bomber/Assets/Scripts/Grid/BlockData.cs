using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bomber.Grid
{
    public class BlockData : MonoBehaviour
    {
        [SerializeField] private TypeBlock _type;

        public TypeBlock GetTypeBlock()
        {
            return _type;
        }
    }


    public enum TypeBlock
    {
        Ground,
        Water
    }
}