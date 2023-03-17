using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _coins;
    [SerializeField] private int _damage;


    public int Health
    {
        get { return _health; }

        private set
        {
            if (_health < 0)
                _health = 0;

            _health = value;
        }
    }

    public int Coins => _coins;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        Health -= damage;
    }
}
