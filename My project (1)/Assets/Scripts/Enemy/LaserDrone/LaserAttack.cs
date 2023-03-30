using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    [SerializeField] private float _distance = 100f;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _shootPoint;

    private Transform _transformation;

    private void Awake()
    {
        _transformation = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    private void ShootLaser()
    {
        if(Physics2D.Raycast(_transformation.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(_transformation.position, transform.right);
            Draw2DRay(_shootPoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(_shootPoint.position, _shootPoint.transform.right *  _distance);
        }
    }

    private void Draw2DRay(Vector2 startPosition, Vector2 endPosition)
    {
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);
    }
}
