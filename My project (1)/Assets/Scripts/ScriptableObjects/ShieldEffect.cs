using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ShieldEffect", order = 2)]
public class ShieldEffect : PowerUpEffect
{
    [SerializeField] private float _duration;
    [SerializeField] private float _maxShield;

    private float _currentShield;

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.TryGetComponent<ShieldController>(out var shieldController))
        {
            shieldController.SetMaxShield(_maxShield);
            shieldController.SetCurrentShield(_maxShield);
            shieldController.StartShield(_duration);
        }
    }
}
