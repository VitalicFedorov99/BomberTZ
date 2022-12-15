using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bomber.Enemies
{
    public class AnimationEnemy : MonoBehaviour
    {

        private Animator _animator;
        private const string _strAttack = "Attack";
        private const string _strDie = "Die";




        public void Setup()
        {
            _animator = GetComponent<Animator>();
        }

        public void StateAttack()
        {
            _animator.SetTrigger(_strAttack);
        }

        public void StateDie()
        {
            _animator.SetTrigger(_strDie);
        }
    }
}
