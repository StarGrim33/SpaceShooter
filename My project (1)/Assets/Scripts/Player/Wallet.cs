using System;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coins;

    public event UnityAction MoneyChanged;

    private static Wallet _instance;

    public static Wallet Instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
    }

    public int Coins { get { return _coins; } private set { _coins = value; } }

    public void AddCoins(int value)
    {
        if(value < 0) 
            throw new ArgumentException("Value cannot be negative", nameof(value));

        Coins += value;
        MoneyChanged.Invoke();
    }

    public void RemoveCoins(int value)
    {
        if (value < 0 || _coins <= 0)
            throw new ArgumentException("Value cannot be negative", nameof(value));

        Coins -= value;
        MoneyChanged.Invoke();
    }
}
