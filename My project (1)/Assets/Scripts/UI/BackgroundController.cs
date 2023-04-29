using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float _delay = 300f; 
    [SerializeField] private Texture[] _newBackground; 
    [SerializeField] private RawImage _background;

    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = _background.color;
        StartCoroutine(ChangeBackgroundCoroutine());
    }

    private IEnumerator ChangeBackgroundCoroutine()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (_newBackground.Length != 0)
        {
            yield return waitForSeconds;

            float duration = 1f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                _background.color = Color.Lerp(_defaultColor, Color.clear, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            int randomTextureIndex = UnityEngine.Random.Range(0, _newBackground.Length);
            _background.texture = _newBackground[randomTextureIndex];

            elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                _background.color = Color.Lerp(Color.clear, _defaultColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
