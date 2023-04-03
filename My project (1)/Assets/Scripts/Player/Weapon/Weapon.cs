using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isBuyed = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Sprite => _sprite;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform shootPosition);

    public void Buy()
    {
        _isBuyed = true;
    }
}
