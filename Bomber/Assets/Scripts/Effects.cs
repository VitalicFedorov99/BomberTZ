using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bomber.ObjectPooled;

public class Effects : MonoBehaviour, IPooledObject
{
    [SerializeField] private TypeObjectInPool _type;
    [SerializeField] private float _timer;
    private ParticleSystem _particle;
    public TypeObjectInPool TypeObject => _type;


    public void Setup() 
    {
        _particle = GetComponent<ParticleSystem>();
    }
    public void CreateEffect(Transform pos, Transform _posBomb) 
    {
        transform.position = pos.position;
        if (Vector3.Distance(_posBomb.position, pos.position) < 3f) ;
        _particle.Play();
        StartCoroutine(CoroutineTimerEffect());
    }

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
    
    private IEnumerator CoroutineTimerEffect() 
    {
        yield return new WaitForSeconds(_timer);
        DestroyObject();
    }
}
