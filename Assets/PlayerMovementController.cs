using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _previousPosition;
    private Vector2 _currentPosition;
    private Vector2 _nextMovement;
    private Camera _mainCamera;
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
    public Vector2 Velocity { get; protected set; }


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _currentPosition = _rigidbody2D.position;
        _previousPosition = _rigidbody2D.position;

        Physics2D.queriesStartInColliders = false;
        _mainCamera = Camera.main;
        _mainCamera.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _previousPosition = _rigidbody2D.position;
        _currentPosition = _previousPosition + _nextMovement;
        Velocity = (_currentPosition - _previousPosition) / Time.deltaTime;

        _rigidbody2D.MovePosition(_currentPosition);
        _mainCamera.transform.position = new Vector3(_currentPosition.x, _currentPosition.y + 3, -10);
        _nextMovement = Vector2.zero;
    }

    public void Move(Vector2 movement)
    {
        _nextMovement += movement;
    }
}
