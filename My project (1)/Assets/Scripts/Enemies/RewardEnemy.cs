using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class RewardEnemy : MonoBehaviour
{
    [SerializeField] private int _reward;

    private Wallet _wallet;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _wallet = Wallet.Instance;
    }

    private void OnEnable()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyHealth.Dying += OnEnemyDying;
    }

    private void OnDisable()
    {
        _enemyHealth.Dying -= OnEnemyDying;
    }

    private void OnEnemyDying(EnemyHealth enemy)
    {
        PayReward(_reward);
    }

    public void PayReward(int reward)
    {
        _wallet.AddCoins(reward);
    }
}
