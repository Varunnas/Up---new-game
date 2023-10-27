using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public float enemySpawnRate;
    public float powerUpSpawnrate = 7.0f;
    public bool isGameActive = false;   
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lives;
    private int scores=0;
    public int livesCount = 3;
    public AudioClip soundFx;
    public AudioClip deathSound;
    private AudioSource audioSource;
    public AudioClip hurtAudio;
    public void StartGame(float spawnrates)
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        enemySpawnRate = spawnrates;
        InvokeRepeating("SpawnEnemy",2.0f,enemySpawnRate);
        InvokeRepeating("SpawnPowerup", 5.0f, powerUpSpawnrate);
        InvokeRepeating("UpdateScore", 0.0f, 0.3f);
    }

   
    void UpdateScore()
    {
        if(isGameActive) 
        {
            scores += (3);
            scoreText.text = "Score : " + scores;
        }
    }

    void SpawnEnemy()
    {
        if (isGameActive)
        {
            
            int enemyElement = Random.Range(0, enemyPrefabs.Length);
            float randomPos = Random.Range(15, -15);
            Instantiate(enemyPrefabs[enemyElement], new Vector3(randomPos, 25, enemyPrefabs[enemyElement].transform.position.z), enemyPrefabs[enemyElement].transform.rotation);
        }
 
          
    }

    void SpawnPowerup()
    {
        if (isGameActive) 
        {
            int powerupElement = Random.Range(0, powerupPrefabs.Length);
            float randomPosX = Random.Range(15, -15);
            float randomY = Random.Range(15, 5);
            Instantiate(powerupPrefabs[powerupElement], new Vector3(randomPosX, randomY, powerupPrefabs[powerupElement].transform.position.z), powerupPrefabs[powerupElement].transform.rotation);
        }
        

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Lives()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(hurtAudio, 1.0f);
        livesCount -= 1;
        lives.text = "Lives : " + livesCount;
        if(livesCount == 0)
        {
            GameOver();
            Destroy(GameObject.Find("Baloon"));
        }
    
    }
    public void GameOver()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverScreen.SetActive(true);
        isGameActive = false;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        audioSource.PlayOneShot(deathSound, 1.0f);
    }

    public void SoundEffects()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundFx, 1.0f);
    }
   





}
