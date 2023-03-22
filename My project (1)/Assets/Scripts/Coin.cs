using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private int _coinValue = 100;
}
