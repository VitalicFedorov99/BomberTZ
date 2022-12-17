using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Bomber.ObjectPooled;

namespace Bomber.PlayerSystem
{
    public class InputHero : MonoBehaviour
    {
        [SerializeField] private float _speed;



        private Player _player;
        private Vector3 _direction = Vector3.zero;
        private Vector3 _movement = Vector3.zero;
      


        public void Move(InputAction.CallbackContext context)
        {
            Vector2 moveDirection = context.ReadValue<Vector2>();
            if (context.performed)
            {
                _movement = new Vector3(0, 0, moveDirection.y);
                _direction = new Vector3(moveDirection.x, 0, moveDirection.y);
            }
            if (context.canceled)
            {
                _movement = Vector3.zero;
                _direction = Vector3.zero;
            }
        }
      
        public void CreateBomb()
        {
            if (_player.GetFlagCreateBomb())
            {
                var bomb = ObjectPool.instance.GetObject(_player.GetCurrentBomb());
                bomb.transform.position = transform.position;
                bomb.GetComponent<Bomb>().Setup();
                _player.CreateBomb();
            }
        }


        public void SwitchBomb()
        {
            _player.NextWeapon();
        }

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            Rotation(_direction);
            if (_movement.z == 0 && _direction.x != 0)
            {
                _movement.z = Mathf.Abs(_direction.x);
            }
            if (_movement.z == 0)
            {
                _player.Move(false);
            }
            else
            {
                _player.Move(true);
            }
            transform.Translate(new Vector3(0, 0, Mathf.Abs(_movement.z)) * _speed * Time.deltaTime);
        }
        private void Rotation(Vector3 movement)
        {
            if (movement.x != 0)
                switch (movement.x)
                {
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        break;
                    case -1:
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        break;
                    case 0:
                        break;
                }
            else
                switch (_movement.z)
                {
                    case -1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 0:
                        break;
                }
        }
    }
}


