using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private DamageUpgrade _damagehUpgrade;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _machineGunBullet;
    [SerializeField] private Player _player;
    [SerializeField] private Pool _pool;
    [SerializeField] private MachineGun _machineGun;

    public void BuyDamageUpgrade()
    {
        if (_bullet.GetComponent<Bullet>().Damage < _damagehUpgrade.UpgradeMaxValue && _player.Coins >= _damagehUpgrade.Price)
        {
            _pool.UpdateBullets(_bullet, _damagehUpgrade.UpgradeValue);
            _player.RemoveCoins(_damagehUpgrade.Price);
        }

        if(_machineGun.IsBuyed && _machineGunBullet.GetComponent<MachineGunBullet>().Damage < _damagehUpgrade.UpgradeMaxValue && _player.Coins >= _damagehUpgrade.Price)
        {
            _pool.UpdateBullets(_machineGunBullet, _damagehUpgrade.UpgradeValue);
            _player.RemoveCoins(_damagehUpgrade.Price);
        }
    }
}
