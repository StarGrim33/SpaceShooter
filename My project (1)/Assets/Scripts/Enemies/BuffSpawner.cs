using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _buffs;

    public void CalculateSpawnBuffProbability()
    {
        int minNumber = 0;
        int maxNumber = 100;
        int chance = 50;

        if (Random.Range(minNumber, maxNumber) <= chance && transform.position.x <= 7f)
        {
            SpawnBuff();
        }
    }

    public void SpawnBuff()
    {
        var randomBuff = Random.Range(0, _buffs.Length);
        Instantiate(_buffs[randomBuff], transform.position, Quaternion.identity);
    }
}
