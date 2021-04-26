using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private GameObject _PlayerShieldGameOblect;
    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private int _livesRemaining = 3;

    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private float canFire = 0.0f;

    [SerializeField]
    private float _boost = 1.0f;

    [SerializeField]
    private bool _shield = false;

    [SerializeField]
    private bool _canTripleShot = false;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShootPrefab;

    [SerializeField]
    private float _horizontalSpeed = 7.5f, _verticalSpeed = 7.5f;

    private UIManager myUIManager;
    private GameManager _myGameManager;

    private AudioSource _audioSource;


    private void Start()
    {      
        transform.position = new Vector3(0, -1, 0);

        myUIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (myUIManager != null)
        {
            myUIManager.UpdateLives(_livesRemaining);
        }
        _myGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        if (canFire < Time.time)
            {
                _audioSource.Play();
                if (_canTripleShot)
                {
                    Instantiate(_tripleShootPrefab, transform.position, Quaternion.identity);
                }
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
                canFire = Time.time + fireRate;
            }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (transform.position.x < -7.5f)
        {
            if (horizontalInput < 0)
            {
                horizontalInput = 0;
            }
        }
        else if (transform.position.x > 7.5f)
        {
            if (horizontalInput > 0)
            {
                horizontalInput = 0;
            }
        }
        if (transform.position.y < -4.2f)
        {
            if (verticalInput < 0)
            {
                verticalInput = 0;
            }
        }
        else if (transform.position.y > 0.0f)
        {
            if (verticalInput > 0)
            {
                verticalInput = 0;
            }
        }

        transform.Translate(Vector3.right * _horizontalSpeed * _boost * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _verticalSpeed * _boost * verticalInput * Time.deltaTime);
    }


    public void Damage()
    {
        if (_shield)
        {
            _shield = false;
            _PlayerShieldGameOblect.SetActive(false);
        }
        else
        {
            _livesRemaining--;
            myUIManager.UpdateLives(_livesRemaining);
            if (_livesRemaining < 1)
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);
                _myGameManager.GameOver = true;
                myUIManager.ShowTitleScreen();
                Destroy(this.gameObject);
            }
        }
    }


    public void TripleShotPowerUpOn()
    {
        _canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutiene());
    }

    private IEnumerator TripleShotPowerDownRoutiene()
    {
        yield return new WaitForSeconds(5.0f);
        _canTripleShot = false;
    }

    public void SpeedUpPowerUp()
    {
        _boost = 1.5f;
        StartCoroutine(SpeedUpPowerDownRoutine());
    }

    private IEnumerator SpeedUpPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _boost = 1.0f;
    }

    public void ShieldPowerUp()
    {
        _shield = true;
        _PlayerShieldGameOblect.SetActive(true);
    }
}
