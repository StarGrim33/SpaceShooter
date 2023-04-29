using UnityEngine;

public class HunterAttack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _bullets;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Shoot();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bullets = Pool.SharedInstance.GetObject(_bullets);
        bullets.transform.position = _shootPoint.position;
        bullets.SetActive(true);
    }
}
