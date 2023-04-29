using UnityEngine;
using UnityEngine.Events;

public interface IHealth
{
    public int MaxHealth { get; }

    public int CurrentHealth { get; }

    public void TakeDamage(int damage);
    public void Die();
}
