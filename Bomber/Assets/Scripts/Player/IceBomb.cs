using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Bomber.Pathfinder;
using Bomber.Enemies;
using Bomber.ObjectPooled;


namespace Bomber.PlayerSystem
{
    public class IceBomb : Bomb
    {
        public override TypeObjectInPool TypeObject => TypeObjectInPool.IceBomb;
        protected override void Interactions(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent(out Water water))
            {
                if (!_listBangs.Contains(hit))
                {
                    _listBangs.Add(hit);

                }
                if (water.GetTypeObjectOnWater() == TypeObjectOnWater.Nun)
                {
                    water.CreateIce();
                }
            }

            if (hit.collider.TryGetComponent(out Ground ground))
            {
                if (!_listBangs.Contains(hit))
                {
                    _listBangs.Add(hit);
                }
            }

            if (hit.collider.TryGetComponent(out Wall wall))
            {
                if (!_listBangs.Contains(hit))
                {
                    _listBangs.Add(hit);

                }
                wall.GetComponent<LocatePosition>().SearchPlace().GetComponent<PathNode>().SetStatePathNode(StatePathNode.Walkable);
                Destroy(wall.gameObject);
            }
            if (hit.collider.TryGetComponent(out Player player))
            {
                if (!_listBangs.Contains(hit))
                {
                    _listBangs.Add(hit);
                }
                player.Die();
            }
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                if (!_listBangs.Contains(hit))
                {
                    _listBangs.Add(hit);

                }
                enemy.Die();
            }
        }
    }
}