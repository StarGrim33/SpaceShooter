using UnityEngine;
using UnityEngine.UI;

public class DamageUpgrader : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private DamageUpgrade _damageUpgrade;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _machineGunBullet;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private MachineGunPool _machineGunPool;
    [SerializeField] private BlasterPool _blasterPool;

    public void BuyDamageUpgrade()
    {
        if (_wallet.Coins >= _damageUpgrade.Price)
        {
            _blasterPool.UpdateBullets(_damageUpgrade.UpgradeValue);
            _wallet.RemoveCoins(_damageUpgrade.Price);
            _machineGunPool.UpdateBullets(_damageUpgrade.UpgradeValue);
        }
    }
}
