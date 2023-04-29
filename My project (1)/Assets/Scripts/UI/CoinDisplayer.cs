using TMPro;
using UnityEngine;

public class CoinDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Wallet _wallet;

    private int _previousCoins;

    private void Awake()
    {
        _previousCoins = _wallet.Coins;
        _wallet.MoneyChanged += DisplayCoins;
        DisplayCoins();
    }

    private void Update()
    {
        if (_wallet.Coins != _previousCoins)
        {
            _previousCoins = _wallet.Coins;
            DisplayCoins();
        }
    }

    public void DisplayCoins()
    {
        string text = _wallet.Coins.ToString();
        _money.text = text;
    }
}
