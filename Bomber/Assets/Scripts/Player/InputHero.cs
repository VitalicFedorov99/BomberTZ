using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHero : MonoBehaviour
{


    [SerializeField] private float _cooldown;

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _test;
    private Player _player;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _movement = Vector3.zero;
    private bool _flag = true;
    private Rigidbody _rg;
    private BoxCollider _coll;
    RaycastHit m_Hit;
    bool m_HitDetect;
    float m_MaxDistance = 300f;
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
    private void Awake()
    {
        _rg = GetComponent<Rigidbody>();
        _coll = GetComponent<BoxCollider>();
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

    void FixedUpdate()
    {
        m_HitDetect = Physics.BoxCast(_coll.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance); ;
        if (m_HitDetect)
        {
        }
    }

    private void Rotation(Vector3 movement)
    {
        if(movement.x!=0)
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
    public void CreateBomb()
    {
        if (_flag)
        {
            _flag = false;
            var bomb = ObjectPool.instance.GetObject(_player.GetCurrentBomb());
            //var effect = ObjectPool.instance.GetObject(TypeObjectInPool.IceEffect);
            //effect.GetComponent<Effects>().Setup();
            bomb.transform.position = transform.position;
            bomb.GetComponent<Bomb>().Setup();
            //var bomb = Instantiate(_bombPrefab[_idBomb], transform.position, Quaternion.identity);
            // bomb.Setup();
            StartCoroutine(CoroutineCooldown());
        }
    }


    public void SwitchBomb()
    {
        _player.NextWeapon();
    }

    private IEnumerator CoroutineCooldown()
    {
        _flag = false;
        yield return new WaitForSeconds(_cooldown);
        _flag = true;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, _movement * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}


