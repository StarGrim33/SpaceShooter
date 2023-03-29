using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterShield : MonoBehaviour
{
    [SerializeField] private Enemy _hunter;
    [SerializeField] private SpriteRenderer _shield;
    private bool _isShieldActive = true;

    private void Update()
    {
        DisableShield();
    }

    private void DisableShield()
    {
        if( _isShieldActive && _hunter.Health <= 150)
        {
            _shield.enabled = false;
            _isShieldActive = false;
        }
    }
}
