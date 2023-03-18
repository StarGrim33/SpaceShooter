using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] private Bullet _bullet;

    public override void Shoot(Transform shootPoint)
    {
        GameObject instance = Pool.SharedInstance.GetPooledObject();
        instance.transform.position = shootPoint.position;
        instance.SetActive(true);
    }
}
