using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class MoverRightLeft : MonoBehaviour
{
    [SerializeField] private float _speed;
    private EnemyHealth _enemyHealth;
    private int _displayBorder = -12;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x -= _speed * Time.deltaTime;

        if (position.x < _displayBorder)
            _enemyHealth.Die();

        transform.position = position;
    }
}
