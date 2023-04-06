using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _value;
    [SerializeField] private int _maxValue;
    [SerializeField] private int _price;

    public int Price => _price;
    public int UpgradeValue => _value;
    public int UpgradeMaxValue => _maxValue;

}
