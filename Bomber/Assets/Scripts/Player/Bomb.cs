using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Bomb : MonoBehaviour, IPooledObject
{
    [SerializeField] private float _distanceBang;
    [SerializeField] private float _timer;
    [SerializeField] private TypeObjectInPool _typeEffect;
    [SerializeField] private Effects _effects;
    
    protected List<RaycastHit> _listBangs;
    private LocatePosition _locatePosition;
    //protected Effects _effect;
    public virtual TypeObjectInPool TypeObject => TypeObjectInPool.Bomb;

    public void Setup()
    {
        //Debug.LogError("ѕередаю Ёффект " + typeEffect.ToString());
        //_effect = effects;
        _locatePosition = GetComponent<LocatePosition>();
        _listBangs=new List<RaycastHit>();
        
        //_effects = effects;
        StartCoroutine(CoroutuneBang());
    }


    protected virtual void Interactions(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out Water water))
        {
            if (!_listBangs.Contains(hit)) 
            {
                _listBangs.Add(hit);
               
            }
            water.DestroyIce();
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
        if (hit.collider.TryGetComponent(out Enemy enemy))
        {
            if (!_listBangs.Contains(hit))
            {
                _listBangs.Add(hit);
                
            }
            enemy.Die();
            
        }
        if (hit.collider.TryGetComponent(out Ground ground)) 
        {
            if (!_listBangs.Contains(hit))
            {
                _listBangs.Add(hit);
            }
        }
        if(hit.collider.TryGetComponent(out Player player)) 
        {
            if (!_listBangs.Contains(hit))
            {
                _listBangs.Add(hit);
            }
            player.TakeDamage(10000);
        }
        
    }
    private void Bang()
    {

        var place = _locatePosition.SearchPlace();
        var neighbours = place.GetComponent<PathNode>().GetNeighbours();

        foreach (var neighbour in neighbours)
        {
           
            var objectsHits = neighbour.GetComponent<LocatePosition>().SearchObjects();
            foreach (var obj in objectsHits)
            {
              
                Interactions(obj);
            }
        }
        foreach (var obj in _locatePosition.SearchObjects())
        {
            Interactions(obj);
        }
        foreach (var hit in _listBangs)
        {
            var effect = ObjectPool.instance.GetObject(_typeEffect);
            effect.GetComponent<Effects>().Setup();
            effect.GetComponent<Effects>().CreateEffect(hit.transform);
        }
        DestroyObject();
        
    }

    private IEnumerator CoroutuneBang()
    {
        yield return new WaitForSeconds(_timer);
        Bang();
    }

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }


}
