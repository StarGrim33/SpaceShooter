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

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            _spriteRenderer.enabled = true;
            _boxCollider.enabled = true;
            _audioSource.Play();

            if (Physics2D.Raycast(_shootPoint.position, _shootPoint.right, _distance))
            {
                RaycastHit2D _hit = Physics2D.Raycast(_shootPoint.position, _shootPoint.right, _distance);
                Player player = _hit.collider.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(_damage);
                }
            }
            else
            {
            }

            yield return new WaitForSeconds(1.0f);

            _spriteRenderer.enabled = false;
            _boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(_damage);
        }
    }
}
