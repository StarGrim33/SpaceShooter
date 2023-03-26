using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff",  order = 1)]
public class SpeedBuff : PowerUpEffect
{
    [SerializeField] private float _amount;
    [SerializeField] private float _duration;

    public override void ApplyPowerUp(GameObject target)
    {
        target.GetComponent<PlayerMovement>().ChangeSpeed(_amount, _duration);
    }
}
