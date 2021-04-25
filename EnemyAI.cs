using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 5.0f;

    [SerializeField]
    private GameObject _enemyExplosion;

    private UIManager _UIManager;

    // Start is called before the first frame update
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }

    private void enemyMovement()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if (transform.position.y < -6.25f)
        {
            float randomX = Random.Range(-7, 7);
            transform.position = new Vector3(randomX, 6.5f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player myplayer = other.GetComponent<player>();
            if (myplayer != null)
            {
                myplayer.Damage();
            }
            Instantiate(_enemyExplosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        else if (other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Instantiate(_enemyExplosion, this.transform.position, Quaternion.identity);
            _UIManager.UpdateScore();
            Destroy(this.gameObject);
        }
    }
}