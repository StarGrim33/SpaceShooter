using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    private float _duration;

    public abstract void ApplyPowerUp(GameObject target);
}
