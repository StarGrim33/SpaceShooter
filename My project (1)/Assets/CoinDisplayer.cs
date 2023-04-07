using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CoinDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.MoneyChanged += OnCoinChanged;
        DisplayCoins();
    }

    private void OnCoinChanged()
    {
        DisplayCoins();
    }

    public void DisplayCoins()
    {
        string text = _player.Coins.ToString();
        _money.text = text;
    }
}
