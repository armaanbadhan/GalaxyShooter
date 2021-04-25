using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameOver = true;
    
    [SerializeField]
    private GameObject _player;

    private UIManager _UIManager;
    private SpawnManager _SpawnManager;

    private void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void Update()
    {
        if (GameOver && Input.GetKeyDown(KeyCode.Space))
        {
            GameOver = false;
            Instantiate(_player, new Vector3(0, -1, 0), Quaternion.identity);
            _SpawnManager.StartSpawning();
            _UIManager.HideTitleScreen();
        }
    }
}
