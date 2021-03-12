using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private Mine _mine;
    [SerializeField] private Transform _mineSpawnPlaceLeft;
    [SerializeField] private Transform _mineSpawnPlaceRight;
    private Transform _mineSpawnPlace;

    private void Awake()
    {
        _mineSpawnPlace = _mineSpawnPlaceRight;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _mine.Move(_mineSpawnPlace.position);
        }
    }

    public void SetDirection(bool right)
    {
        if (right)
        {
            _mineSpawnPlace = _mineSpawnPlaceRight;
        }
        else
        {
            _mineSpawnPlace = _mineSpawnPlaceLeft;
        }
    }
}
