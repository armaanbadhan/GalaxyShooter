using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyShipPrefab;

    [SerializeField]
    private GameObject[] _powerUps;

    private GameManager _GameManager;

    private void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StartSpawning()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }


    IEnumerator EnemySpawnRoutine()
    {
        while (!_GameManager.GameOver)
        {
            float randomX = Random.Range(-7, 7);
            Instantiate(_enemyShipPrefab, new Vector3(randomX, 6.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (!_GameManager.GameOver)
        {
            int randomPowerUp = Random.Range(0, 3);
            float randomX = Random.Range(-7, 7);
            Instantiate(_powerUps[randomPowerUp], new Vector3(randomX, 6.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}