using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _frequency;
    [SerializeField] private bool _isInverted = false;
    private float _sinCenterY;
    
    private void Start()
    {
        _sinCenterY = transform.position.y;
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        float sin = Mathf.Sin(position.x * _frequency) * _amplitude;

        if (_isInverted)
            sin *= -1;

        position.y = _sinCenterY+ sin;
        transform.position = position;
    }
}
