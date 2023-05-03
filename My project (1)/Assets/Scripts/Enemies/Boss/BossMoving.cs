using UnityEngine;

public class BossMoving : MonoBehaviour
{
    private Transform _targetPosition;
    private float _speed = 8f;

    private void Update()
    {
        if (_targetPosition != null)
            Move();
    }

    private void Move()
    {
        Vector3 direction = (_targetPosition.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * _speed * Time.deltaTime;
        transform.position = newPosition;
    }

    public void SetTargetPosition(Transform targetPosition)
    {
        _targetPosition = targetPosition;
    }
}
