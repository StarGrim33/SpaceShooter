using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private SimpleBullet _bullet;
    [SerializeField] private Transform _shootPoint;

    private const string AttackAnimation = "Attack";
    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        _animator.Play(AttackAnimation);
        Shoot(_shootPoint);
    }

    private void Shoot(Transform shootPoint)
    {
        Instantiate(_bullet, shootPoint);
    }
}
