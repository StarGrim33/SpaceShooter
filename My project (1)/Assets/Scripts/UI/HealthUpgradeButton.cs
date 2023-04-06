using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HealthUpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private HealthUpgrade _healthUpgrade;
    [SerializeField] private Health _health;
    [SerializeField] private Player _player;

    public void BuyHealthUpgrade()
    {
        if (_health.MaxHealth < _healthUpgrade.UpgradeMaxValue && _player.Coins >= _healthUpgrade.Price)
        {
            _health.UpgradeHealth(_healthUpgrade.UpgradeValue);
            _player.RemoveCoins(_healthUpgrade.Price);
        }
    }
}
