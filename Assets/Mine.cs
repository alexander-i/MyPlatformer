using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Vector3 _minePosition;

    private Vector3 initialPosition = new Vector3(-100, -100, -100);

    private void Awake()
    {
        _minePosition = initialPosition;
    }

    private void FixedUpdate()
    {
        transform.position = _minePosition;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
            _minePosition = initialPosition;
        }
    }

    public void Move(Vector3 position)
    {
        _minePosition = position;
    }

}
