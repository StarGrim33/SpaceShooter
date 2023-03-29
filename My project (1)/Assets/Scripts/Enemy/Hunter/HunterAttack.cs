using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HunterAttack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _bullets;
    [SerializeField] private int _bulletsAmount = 10;
    [SerializeField] private float _startAngle = 90f;
    [SerializeField] private float _endAngle = 270f;

    private Player _player;
    private float _lastAttackTime;
    private Vector3 _target;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _target = new Vector3(_player.transform.position.x - 10f, _player.transform.position.y);
    }

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
        float angleStep = (_endAngle - _startAngle) / _bulletsAmount;
        float angle = _startAngle;

        for(int i = 0;  i < _bulletsAmount + 1; i++)
        {
            float bulletDirectionY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector3 bulletMoveVector = new Vector3(_target.x, bulletDirectionY);
            Vector2 bulletDirection = (bulletMoveVector - transform.position).normalized;

            GameObject instance = Pool.SharedInstance.GetObject(_bullets);
            instance.transform.position = _shootPoint.position;
            instance.SetActive(true);
            instance.GetComponent<HunterBullet>().SetMoveDirection(bulletDirection);

            angle += angleStep;
        }

    }
}
