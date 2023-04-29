using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyHealth))]
public class Enemy : Unit
{
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Health>(out Health player))
        {
            player.TakeDamage(CollisionDamage);
            _enemyHealth.Die();
        }
    }
}
