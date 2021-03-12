using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _detectionRange;
    private Vector3 _position;
    public bool facingRight = true;

    private void FixedUpdate()
    {
        if (Mathf.Abs(_player.transform.position.x - _position.x) > _detectionRange || Mathf.Abs(_player.transform.position.x - _position.x) <= 3)
        {

        }
        else if (_player.transform.position.x < _position.x)
        {
            _position.x -= _speed;
            if (facingRight) { Flip(); }
        }
        else if (_player.transform.position.x > _position.x)
        {
            _position.x += _speed;
            if (!facingRight) { Flip(); }
        }
        
        transform.position = _position;
    }

    public void Initalize(Vector3 newPosition)
    {
        _position = newPosition;
        _enemyObject.SetActive(true);
    }

    public void Hurt(int damage)
    {
        print("Ouch: " + damage);

        _health -= damage; ;

        if (_health <= 0)
        {
            Die();
            transform.parent.GetComponent<EnemySpawner>().Initialize();
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Die()
    {
        _enemyObject.SetActive(false);
    }
}
