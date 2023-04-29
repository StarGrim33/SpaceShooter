using UnityEngine;

public class Upgrades : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _value;
    [SerializeField] private int _price;

    public int Price => _price;
    public int UpgradeValue => _value;
}
