using System.Collections;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    [SerializeField] private float _distance = 100f;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Collider2D _boxCollider;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _displayLaserTime = 3.0f;
    private float _shootDelay = 2.0f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Health>(out Health player))
        {
            player.TakeDamage(_damage);
        }
    }

    private IEnumerator Shoot()
    {
        var waitForSeconds = new WaitForSeconds(_displayLaserTime);
        var waitForShootDelay = new WaitForSeconds(_shootDelay);

        while (true)
        {
            yield return waitForSeconds;

            _spriteRenderer.enabled = true;
            _boxCollider.enabled = true;
            _audioSource.Play();

            if (Physics2D.Raycast(_shootPoint.position, _shootPoint.right, _distance))
            {
                RaycastHit2D _hit = Physics2D.Raycast(_shootPoint.position, _shootPoint.right, _distance);
                Health player = _hit.collider.GetComponent<Health>();

                if (player != null)
                {
                    player.TakeDamage(_damage);
                }
            }

            yield return waitForShootDelay;

            _spriteRenderer.enabled = false;
            _boxCollider.enabled = false;
        }
    }
}
