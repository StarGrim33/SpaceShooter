using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpEffect _powerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _powerUpEffect.ApplyPowerUp(player.gameObject);
            player.Clip.Play();
            Debug.Log("2dsd");
            Destroy(gameObject);
        }
    }
}
