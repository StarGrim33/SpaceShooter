using UnityEngine;
using TMPro;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyHealthDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        _text.text = _enemyHealth.CurrentHealth.ToString();
    }
}
