using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _animator;
    private const string _strWalk = "Walk";
    private const string _strDie = "Die";
    private const string _strTakeDamage = "TakeDamage";
    void Start()
    {
        _animator = GetComponent<Animator>();        
    }

    public void StateWalk(bool flag) 
    {
        _animator.SetBool(_strWalk, flag);
    }

    public void StateTakeDamage() 
    {
        _animator.SetTrigger(_strTakeDamage);

    }

    public void StateDie() 
    {
        _animator.SetTrigger(_strDie);
    }
   
}
