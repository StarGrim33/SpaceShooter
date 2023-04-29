using UnityEngine;

public class BossMoving : MonoBehaviour
{
    private Transform _targetPosition;
    private float _speed = 8f;

    private void Awake()
    {
        _targetPosition = GameObject.Find("BossTargetPosition").transform;
    }

    private void Update()
    {
        Vector3 direction = (_targetPosition.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * _speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
