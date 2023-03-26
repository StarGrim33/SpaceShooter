using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private GameObject _shieldVisual;
    [SerializeField] private float _maxShield;
    [SerializeField] private float _currentShield;
    [SerializeField] private bool _isShieldActive = false;
    [SerializeField] private SpriteRenderer _playerShieldSprite;

    public bool IsShieldActive => _isShieldActive;

    public void SetMaxShield(float value)
    {
        _maxShield = value;
    }

    public void SetCurrentShield(float value)
    {
        _currentShield = value;
    }

    public void StartShield(float duration)
    {
        _isShieldActive = true;
        _playerShieldSprite.enabled = true;
        StartCoroutine(ShieldDurationCoroutine(duration));
    }

    private IEnumerator ShieldDurationCoroutine(float duration)
    {
        var waitForSeconds = new WaitForSeconds(duration);
        _shieldVisual.SetActive(true);

        yield return waitForSeconds;

        _shieldVisual.SetActive(false);
        _isShieldActive = false;
        _playerShieldSprite.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        if (_isShieldActive)
        {
            _currentShield -= damage;

            if (_currentShield <= 0f)
            {
                _currentShield = 0f;
                _shieldVisual.SetActive(false);
                _isShieldActive = false;
                _playerShieldSprite.enabled = false;
            }
        }
    }
}
