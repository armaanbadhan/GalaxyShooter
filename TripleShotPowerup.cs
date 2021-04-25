using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// one script for all poewrups
public class TripleShotPowerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private float _ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5.75f)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player myplayer = other.GetComponent<player>();
            if (myplayer != null)
            {
                if (_ID == 0)
                {
                    myplayer.TripleShotPowerUpOn();
                }
                else if (_ID == 1)
                {
                    myplayer.SpeedUpPowerUp();
                }
                else if (_ID == 2)
                {
                    myplayer.ShieldPowerUp();
                }
            }
            
            Destroy(this.gameObject);
        }
    }
}
