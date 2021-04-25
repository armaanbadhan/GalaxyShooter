using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyShipPrefab;

    [SerializeField]
    private GameObject[] _powerUps;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            float randomX = Random.Range(-7, 7);
            Instantiate(_enemyShipPrefab, new Vector3(randomX, 6.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (true)
        {
            int randomPowerUp = Random.Range(0, 3);
            float randomX = Random.Range(-7, 7);
            Instantiate(_powerUps[randomPowerUp], new Vector3(randomX, 6.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}