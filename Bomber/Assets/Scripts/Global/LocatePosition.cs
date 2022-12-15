using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LocatePosition : MonoBehaviour
{
    [SerializeField] private GameObject _place;


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
    public void TestSearchPlace()
    {
        RaycastHit[] hitsHorizontalGround = Physics.RaycastAll(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y * (-3), transform.position.z));
        foreach (var hit in hitsHorizontalGround)
        {
            if (hit.collider.TryGetComponent(out BlockData block))
            {
                _place = block.gameObject;
            }
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

    }
    public GameObject GetPlace()
    {
        return _place;
    }

}
