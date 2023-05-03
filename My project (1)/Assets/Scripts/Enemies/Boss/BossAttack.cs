using System.Collections;
using UnityEngine;

public enum BossStages
{
    First = 1,
    Second = 2,
    Third = 3,
}

[RequireComponent(typeof(Boss))]
public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] _attackPrefabs;
    [SerializeField] private Transform[] _attackSpawnPoint;
    [SerializeField] private Boss _boss;

    private float _lastShotTime = 0f;
    private float _shotDelay = 0.8f;
    private float _shotDelaySecondPhase = 0.6f;
    private float _shotDelayThirdPhase = 0.5f;
    private int _shotsAmountFirstPhase = 5;
    private int _shotAmountSecondPhase = 7;
    private int _shotAmountThirdPhase = 8;

    private void OnEnable()
    {
        _boss.StageChanged += OnBossStageChanged;
    }

    private void OnBossStageChanged(int stageNumber)
    {
        if (stageNumber == (int)BossStages.Second)
        {
            _shotDelay = _shotDelaySecondPhase;
        }
        else if (stageNumber == (int)BossStages.Third)
        {
            _shotDelay = _shotDelayThirdPhase;
        }
    }

    private void Update()
    {
        StartCoroutine(Assail());
    }

    private void Shoot()
    {
        if (_boss.CurrentPhase <= _attackPrefabs.Length)
        {
            if (_boss.CurrentPhase == (int)BossStages.First)
            {
                int randomShootPoint = Random.Range(0, _attackSpawnPoint.Length);

                for (int i = 0; i <= _shotsAmountFirstPhase; i++)
                {
                    GameObject attack = Pool.SharedInstance.GetObject(_attackPrefabs[_boss.CurrentPhase - 1]);

                    if (attack != null)
                    {
                        attack.transform.position = _attackSpawnPoint[randomShootPoint].position;
                        attack.SetActive(true);
                    }
                }
            }
            else if (_boss.CurrentPhase == (int)BossStages.Second)
            {
                int randomShootPoint = Random.Range(0, _attackSpawnPoint.Length);

                for (int i = 0; i <= _shotAmountSecondPhase; i++)
                {
                    GameObject attack = Pool.SharedInstance.GetObject(_attackPrefabs[_boss.CurrentPhase - 1]);

                    if (attack != null)
                    {
                        attack.transform.position = _attackSpawnPoint[randomShootPoint].position;
                        attack.SetActive(true);
                    }
                }
            }
            else if( _boss.CurrentPhase == (int)BossStages.Third)
            {
                int randomShootPoint = Random.Range(0, _attackSpawnPoint.Length);

                for (int i = 0; i <= _shotAmountThirdPhase; i++)
                {
                    GameObject attack = Pool.SharedInstance.GetObject(_attackPrefabs[_boss.CurrentPhase - 1]);

                    if (attack != null)
                    {
                        attack.transform.position = _attackSpawnPoint[randomShootPoint].position;
                        attack.SetActive(true);
                    }
                }
            }
        }
    }

    private IEnumerator Assail()
    {
        var waitForSeconds = new WaitForSeconds(_shotDelay);

        if (Time.time - _lastShotTime >= _shotDelay)
        {
            Shoot();
            _lastShotTime = Time.time;
        }

        yield return waitForSeconds;
    }
}
