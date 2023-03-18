using System.Collections;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private Transform _target;

    private PoolObject _poolObject;

    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
        _target = FindObjectOfType<Player>().transform;
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _target.position);

        if (distance > 0.1f)
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private IEnumerator Destroy()
    {
        var waitForSeconds = new WaitForSeconds(_lifeTime);
        yield return waitForSeconds;
        Destroy(gameObject);
    }
}
