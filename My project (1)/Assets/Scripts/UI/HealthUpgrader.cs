using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrader : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private HealthUpgrade _healthUpgrade;
    [SerializeField] private Health _health;
    [SerializeField] private Wallet _wallet;

    public void BuyHealthUpgrade()
    {
        if (_wallet.Coins >= _healthUpgrade.Price)
        {
            _health.UpgradeHealth(_healthUpgrade.UpgradeValue);
            _wallet.RemoveCoins(_healthUpgrade.Price);
        }
    }
}
