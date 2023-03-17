using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offSet;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _offSet, transform.position.y, transform.position.z);
    }
}
