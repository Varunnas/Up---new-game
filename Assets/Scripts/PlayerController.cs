using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float horizonatalValue;
    private float verticalValue;
    private float upperBound = 17;
    private float lowerBound = 3.9f;
    private float sideBound = 16.2f;
    public float speed;
    private bool powerUp = false;
    public GameObject powerUpIndicator;
    private Rigidbody enemyRb;
    private GameManager gameManagerScript;
    public ParticleSystem explosion;
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
        
    }

    private void LateUpdate()
    {
        PlayerBorder();   
    }

    private void PlayerBorder()
    {
        if (transform.position.y > upperBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
        }
        else if (transform.position.y < lowerBound)
        {
            transform.position = new Vector3(transform.position.x,lowerBound, transform.position.z);
        }

        if (transform.position.x > sideBound)
        {
            transform.position = new Vector3(-sideBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -sideBound)
        {
            transform.position = new Vector3(sideBound, transform.position.y, transform.position.z);
        }
    }

    private void PlayerMovement()
    {
        horizonatalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonatalValue);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            powerUp = true;
            StartCoroutine(PowerUpCountDown());
        }
        else if (other.gameObject.CompareTag("Powerup2"))
        {
            Destroy(other.gameObject);
            gameManagerScript.livesCount += 1;
            gameManagerScript.lives.text = "Lives : " + gameManagerScript.livesCount;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        enemyRb = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (powerUp)
            {
                enemyRb.AddForce(Vector3.up * 20, ForceMode.Impulse);
            }
            else
            {
                Instantiate(explosion , transform.position , transform.rotation);
                gameManagerScript.Lives();
                Destroy(collision.gameObject);
            }
        }          
    }

        IEnumerator PowerUpCountDown()
        {
            yield return new WaitForSeconds(7);
            powerUp = false;
            powerUpIndicator.SetActive(false);
        }
    }
