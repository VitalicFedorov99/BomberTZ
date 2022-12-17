using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.Grid;


public class LocatePosition : MonoBehaviour
{
    private GameObject _place;


    public GameObject SearchPlace()
    {

        RaycastHit[] hitsHorizontalGround = Physics.RaycastAll(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.down, 3);
        foreach (var hit in hitsHorizontalGround)
        {

            if (hit.collider.TryGetComponent(out BlockData block))
            {
                _place = block.gameObject;
            }
        }

        return _place;
    }

    public List<RaycastHit> SearchObjects()
    {
        RaycastHit[] objects = Physics.BoxCastAll(transform.position, transform.localScale / 4, transform.up);
        RaycastHit[] objects1 = Physics.BoxCastAll(transform.position, transform.localScale / 4, -transform.up);
        List<RaycastHit> listObjects = new List<RaycastHit>();
        foreach (var obj in objects)
        {
            listObjects.Add(obj);
        }
        foreach (var obj in objects1)
        {
            listObjects.Add(obj);
        }

        return listObjects;
    }
    public GameObject GetPlace()
    {
        return _place;
    }
   



}
