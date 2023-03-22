using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRightLeft : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x -= _speed * Time.deltaTime;

        if (position.x < -12)
            _enemy.Die();

        transform.position = position;
    }
}
