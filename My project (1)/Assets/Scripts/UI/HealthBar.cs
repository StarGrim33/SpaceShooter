using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _fadeTime = 50f;
    [SerializeField] private TMP_Text _text;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _health.Reduced += OnHealthReduced;
        _health.Incresead += OnHealthIncreased;
        string text = "HP: " + _health.CurrentHealth.ToString();
        _text.text = text;
    }

    private void OnDestroy()
    {
        _health.Reduced -= OnHealthReduced;
        _health.Incresead -= OnHealthIncreased;
    }

    private void FadeSliderValueChange(float healthTarget)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SliderValueChange(healthTarget));
    }

    private IEnumerator SliderValueChange(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _fadeTime * Time.deltaTime);
            yield return null;
        }
    }

    public void OnHealthReduced(int currentHealth)
    {
        HealthDisplay();
        FadeSliderValueChange(currentHealth);
    }

    public void OnHealthIncreased(int currentHealth)
    {
        HealthDisplay();
        FadeSliderValueChange(currentHealth);
    }

    public void HealthDisplay()
    {
        string text = "HP: " + _health.CurrentHealth.ToString();
        _text.text = text;
    }
}
