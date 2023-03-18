using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> Reduced;
    public event UnityAction<int> Incresead;

    public int CurrentHealth
    {
        get { return _health; }
        private set
        {
            _health = Mathf.Clamp(value, 0, _health);
        }
    }

    public void Heal(int heal)
    {
        CurrentHealth += heal;
        Debug.Log(CurrentHealth);
        Incresead?.Invoke(CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log(CurrentHealth);
        Reduced?.Invoke(CurrentHealth);
    }
}
