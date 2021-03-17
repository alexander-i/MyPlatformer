using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;
    public bool facingRight = true;


    protected Vector2 _moveVector;
    protected PlayerMovementController _playerMovementController;
    
    private MineSpawner _mineSpawner;
    // Start is called before the first frame update
    void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _mineSpawner = GetComponent<MineSpawner>();
    }

    private void Update()
    {
        _moveVector.x = Input.GetAxis("Horizontal"); // значит клавиши a/d
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            _moveVector.y = 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _moveVector.y = 0f;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_moveVector.x < 0)
        {
            if (facingRight) { Flip(); }
            _mineSpawner.SetDirection(!facingRight);
        }
        else if (_moveVector.x > 0)
        {
            if (!facingRight) { Flip(); }
            _mineSpawner.SetDirection(facingRight);
        }
        _playerMovementController.Move(_moveVector * _speed * Time.deltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
