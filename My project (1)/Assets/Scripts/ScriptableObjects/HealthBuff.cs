using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(menuName = "Powerups/HealthBuff", order = 0)]
public class HealthBuff : PowerUpEffect
{
    [SerializeField] private int _amount;
    [SerializeField] private float _duration;

    public override void ApplyPowerUp(GameObject target)
    {
        target.GetComponent<Health>().Heal(_amount);
    }
}
