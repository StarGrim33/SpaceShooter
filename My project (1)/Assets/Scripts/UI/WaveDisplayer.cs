using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WaveDisplayer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _text.text = _spawner.CurrentWave.ToString();
    }

    private void OnEnable()
    {
        _spawner.WaveChanged += OnWaveChanged;
    }

    private void OnDisable()
    {
        _spawner.WaveChanged -= OnWaveChanged;

    }

    private void OnWaveChanged()
    {
        DisplayWaveNumber();
    }

    public void DisplayWaveNumber()
    {
        _text.text = _spawner.CurrentWave.ToString();
    }
}
