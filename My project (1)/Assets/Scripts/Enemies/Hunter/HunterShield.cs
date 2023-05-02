using UnityEngine;

public class HunterShield : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private SpriteRenderer _shield;

    private bool _isShieldActive = true;
    private int _shieldDisableValue = 150;

    private void Update()
    {
        DisableShield();
    }

    private void DisableShield()
    {
        if (_isShieldActive && _health.CurrentHealth <= _shieldDisableValue)
        {
            _shield.enabled = false;
            _isShieldActive = false;
        }
    }
}
