using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] private GameObject _playerBullet;

    private int _criticalDamage = 15;
    private int _chance = 5;

    private void ResetDamage()
    {
        _criticalDamage = 0;
    }

    public override void Shoot(Transform shootPoint)
    {
        float randomNum = Random.Range(1, 101);

        if (randomNum <= _chance)
        {
            Bullet instance = BlasterPool.Instance.GetObject();
            instance.UpgradeDamage(_criticalDamage);
            instance.transform.position = shootPoint.position;
            instance.gameObject.SetActive(true);
            ResetDamage();
        }
        else
        {
            Bullet instance = BlasterPool.Instance.GetObject();
            instance.transform.position = shootPoint.position;
            instance.gameObject.SetActive(true);
        }
    }
}
